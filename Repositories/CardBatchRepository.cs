using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Surveillance.Interfaces;
using Surveillance.Models;
using Surveillance.ViewModels;
using Surveillance.Schafold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;


namespace Surveillance.Repositories {

    /// <summary>
    /// 門卡批次
    /// </summary>
    public class CardBatchRepository : ICardBatchRepository {

        private DatabaseContext DatabaseContext;
        private readonly IMapper Mapper;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DatabaseContext">資料庫上下文</param>
        /// <param name="_Mapper">模型映射</param>
        public CardBatchRepository(DatabaseContext _DatabaseContext, IMapper _Mapper) {
            DatabaseContext = _DatabaseContext;
            Mapper = _Mapper;
        }


        #region "讀取"

        /// <summary>
        /// 取得門卡批次
        /// </summary>
        /// <param name="_Seq">流水編號</param>
        /// <returns>CardBatchModel</returns>
        public async Task<CardBatchModel> Get(int _Seq = 0) {
            var Model = await DatabaseContext.CardBatch
                                             .AsQueryable()
                                             .Where(x => x.Seq == _Seq)
                                             .FirstOrDefaultAsync();

            if (Model == null) {
                Model = new CardBatchModel();
            }

            return Model;
        }


        /// <summary>
        /// 取得門卡批次清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(List<CardBatchViewModel> List, int Count)> GetList(CardBatchListEntry _Entry) {
            int PageNow = _Entry.PageNow;
            int PageShow = _Entry.PageShow;
            string Keyword = _Entry.Keyword;
            DateTime StartTime = _Entry.StartTime;
            DateTime EndTime = _Entry.EndTime;

            var Query = DatabaseContext.CardBatch
                                       .AsQueryable()
                                       .GroupJoin(DatabaseContext.Card, cb => cb.CardID, c => c.ID, (cb, c) => new {
                                           CardBatch = cb,
                                           Card = c
                                       })
                                       .SelectMany(x => x.Card.DefaultIfEmpty(), (cb, c) => new CardBatchViewModel {
                                           // Model
                                           Seq = cb.CardBatch.Seq,
                                           CardID = cb.CardBatch.CardID,
                                           HolderID = cb.CardBatch.HolderID,
                                           HolderName = cb.CardBatch.HolderName,
                                           StartTime = cb.CardBatch.StartTime,
                                           EndTime = cb.CardBatch.EndTime,
                                           // ViewModel
                                           StartTimeStr = cb.CardBatch.StartTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                           EndTimeStr = cb.CardBatch.EndTime.ToString("yyyy-MM-dd HH:mm:ss"),
                                           CardNote = c.Note
                                       });

            // 關鍵字
            if (!string.IsNullOrEmpty(Keyword)) {
                Query = Query.Where(x => x.HolderID.Contains(Keyword) || x.HolderName.Contains(Keyword));
            }

            // 開始時間
            if (StartTime != DateTime.MinValue) {
                Query = Query.Where(x => x.StartTime >= StartTime);
            }

            // 結束時間
            if (EndTime != DateTime.MinValue) {
                Query = Query.Where(x => x.EndTime <= EndTime);
            }

            int Count = await Query.CountAsync();

            var List = await Query.OrderBy(x => x.Seq)
                                  .Skip((PageNow - 1) * PageShow)
                                  .Take(PageShow)
                                  .ToListAsync();

            return (List, Count);
        }


        /// <summary>
        /// 取得門卡批次指標
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>int</returns>
        public async Task<int> GetCursor(CardBatchCursorEntry _Entry) {
            int Seq = 0;
            CardBatchModel Model = new CardBatchModel();

            var Query = DatabaseContext.CardBatch.AsQueryable();

            if (_Entry.Direction) {
                Model = await Query.Where(x => x.Seq > _Entry.Seq)
                                   .OrderBy(x => x.Seq)
                                   .FirstOrDefaultAsync();
            } else {
                Model = await Query.Where(x => x.Seq < _Entry.Seq)
                                   .OrderByDescending(x => x.Seq)
                                   .FirstOrDefaultAsync();
            }

            if (Model != null) {
                Seq = Model.Seq;
            }

            return Seq;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增門卡批次
        /// </summary>
        /// <param name="_List">清單</param>
        /// <returns>Task</returns>
        public async Task Set(List<CardBatchModel> _List) {
            DatabaseContext.CardBatch.AddRange(_List);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "修改"

        /// <summary>
        /// 修改門卡批次
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Update(CardBatchModel _Model) {
            var Temp = await DatabaseContext.CardBatch.SingleAsync(x => x.Seq == _Model.Seq);

            if (Temp != null) {
                Temp.CardID = _Model.CardID;
                Temp.HolderID = _Model.HolderID;
                Temp.HolderName = _Model.HolderName;
                Temp.StartTime = _Model.StartTime;
                Temp.EndTime = _Model.EndTime;

                await DatabaseContext.SaveChangesAsync();
            }
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除門卡批次 (依流水編號)
        /// </summary>
        /// <param name="_Seq">流水編號</param>
        /// <returns>Task</returns>
        public async Task DeleteBySeq(int _Seq = 0) {
            var Query = DatabaseContext.CardBatch
                                       .AsQueryable()
                                       .Where(x => x.Seq == _Seq);

            DatabaseContext.CardBatch.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }


        /// <summary>
        /// 刪除門卡批次 (依門卡編號)
        /// </summary>
        /// <param name="_CardID">門卡編號</param>
        /// <returns>Task</returns>
        public async Task DeleteByCard(int _CardID = 0) {
            var Query = DatabaseContext.CardBatch
                                       .AsQueryable()
                                       .Where(x => x.CardID == _CardID);

            DatabaseContext.CardBatch.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }


        /// <summary>
        /// 刪除門卡批次 (依持有者編號)
        /// </summary>
        /// <param name="_HolderID">持有者編號</param>
        /// <returns>Task</returns>
        public async Task DeleteByHolder(string _HolderID = "") {
            var Query = DatabaseContext.CardBatch
                                       .AsQueryable()
                                       .Where(x => x.HolderID == _HolderID);

            DatabaseContext.CardBatch.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }


        /// <summary>
        /// 刪除門卡批次 (依時間)
        /// </summary>
        /// <param name="_StartTime">開始時間</param>
        /// <param name="_EndTime">結束時間</param>
        /// <returns>Task</returns>
        public async Task DeleteByTime(DateTime _StartTime, DateTime _EndTime) {
            var Query = DatabaseContext.CardBatch
                                       .AsQueryable()
                                       .Where(x => x.StartTime >= _StartTime)
                                       .Where(x => x.EndTime <= _EndTime);

            DatabaseContext.CardBatch.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "其它"

        /// <summary>
        /// 檢查門卡批次
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>bool</returns>
        public async Task<bool> CheckAvailable(CardBatchCheckEntry _Entry) {
            bool Flag = false;

            var Model = await DatabaseContext.CardBatch
                                             .AsQueryable()
                                             .AsNoTracking()
                                             .Where(x => x.CardID == _Entry.CardID)
                                             .Where(x => x.HolderID == _Entry.HolderID)
                                             .Where(x => x.StartTime <= _Entry.Time)
                                             .Where(x => x.EndTime >= _Entry.Time)
                                             .FirstOrDefaultAsync();

            if (Model != null) {
                Flag = true;
            }

            return Flag;
        }


        /// <summary>
        /// 匯入門卡批次
        /// </summary>
        /// <param name="_Stream">串流</param>
        /// <param name="_FileType">檔案類型</param>
        /// <returns>bool</returns>
        public async Task<bool> Import(Stream _Stream, string _FileType) {
            bool Flag = false;

            var List = new List<CardBatchModel>();

            using (var SR = new StreamReader(_Stream)) {
                //string[] Header = SR.ReadLine().Split(',');

                while (!SR.EndOfStream) {
                    string[] Rows = SR.ReadLine().Split(',');

                    int.TryParse(Rows[0].ToString(), out int CardID);
                    string HolderID = Rows[1].ToString();
                    string HolderName = Rows[2].ToString();
                    DateTime.TryParse(Rows[3].ToString(), out DateTime StartTime);
                    DateTime.TryParse(Rows[4].ToString(), out DateTime EndTime);
                    
                    List.Add(new CardBatchModel() {
                        CardID = CardID,
                        HolderID = HolderID,
                        HolderName = HolderName,
                        StartTime = StartTime,
                        EndTime = EndTime
                    });
                }

                Flag = true;
            }
            
            // 新增門卡批次
            await Set(List);

            return Flag;
        }

        #endregion

    }
}