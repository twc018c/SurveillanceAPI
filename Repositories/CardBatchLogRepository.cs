using Microsoft.EntityFrameworkCore;
using Surveillance.Interfaces;
using Surveillance.Models;
using Surveillance.ViewModels;
using Surveillance.Schafold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Surveillance.Repositories {

    /// <summary>
    /// 門鎖批次紀錄
    /// </summary>
    public class CardBatchLogRepository : ICardBatchLogRepository {

        private DatabaseContext DatabaseContext;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DatabaseContext">資料庫上下文</param>
        public CardBatchLogRepository(DatabaseContext _DatabaseContext) {
            DatabaseContext = _DatabaseContext;
        }


        #region "讀取"

        /// <summary>
        /// 取得門鎖批次紀錄清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(List<CardBatchLogViewModel> List, int Count)> GetList(CardBatchLogListEntry _Entry) {
            int PageNow = _Entry.PageNow;
            int PageShow = _Entry.PageShow;
            DateTime StartTime = _Entry.StartTime;
            DateTime EndTime = _Entry.EndTime;
            string Keyword = _Entry.Keyword;
            int UserSeq = _Entry.UserSeq;

            var Query = DatabaseContext.CardBatchLog
                                       .AsQueryable()
                                       .GroupJoin(DatabaseContext.User.AsQueryable(), el => el.UserSeq, u => u.Seq, (el, u) => new {
                                           CardBatchLog = el,
                                           User = u
                                       })
                                       .SelectMany(x => x.User.DefaultIfEmpty(), (el, u) => new CardBatchLogViewModel {
                                           // Model
                                           Seq = el.CardBatchLog.Seq,
                                           Time = el.CardBatchLog.Time,
                                           UserSeq = (u == null) ? 0 : u.Seq,
                                           Note = el.CardBatchLog.Note,
                                           // ViewModel
                                           UserName = u.Name ?? "",
                                           TimeStr = el.CardBatchLog.Time.ToString("yyyy-MM-dd HH:mm:ss")
                                       });

            // 開始時間
            if (StartTime != DateTime.MinValue) {
                Query = Query.Where(x => x.Time >= StartTime);
            }

            // 結束時間
            if (EndTime != DateTime.MinValue) {
                Query = Query.Where(x => x.Time <= EndTime);
            }

            // 關鍵字
            if (!string.IsNullOrEmpty(Keyword)) {
                Query = Query.Where(x => x.UserName.Contains(Keyword) || x.Note.Contains(Keyword));
            }

            // 使用者流水編號
            if (UserSeq > 0) {
                Query = Query.Where(x => x.UserSeq == UserSeq);
            }

            int Count = await Query.CountAsync();

            var List = await Query.OrderByDescending(x => x.Time)
                                  .Skip((PageNow - 1) * PageShow)
                                  .Take(PageShow)
                                  .ToListAsync();
            
            return (List, Count);
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增門鎖批次紀錄
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Set(CardBatchLogModel _Model) {
            if (_Model.Time == DateTime.MinValue) {
                _Model.Time = DateTime.Now;
            }

            DatabaseContext.CardBatchLog.Add(_Model);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion

    }
}