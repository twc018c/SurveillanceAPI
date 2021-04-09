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
    /// 事件紀錄
    /// </summary>
    public class EventLogRepository : IEventLogRepository {

        private DatabaseContext DatabaseContext;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DatabaseContext">資料庫上下文</param>
        public EventLogRepository(DatabaseContext _DatabaseContext) {
            DatabaseContext = _DatabaseContext;
        }


        #region "讀取"

        /// <summary>
        /// 取得事件紀錄清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(List<EventLogViewModel> List, int Count)> GetList(EventLogEntry _Entry) {
            int PageNow = _Entry.PageNow;
            int PageShow = _Entry.PageShow;
            DateTime StartTime = _Entry.StartTime;
            DateTime EndTime = _Entry.EndTime;
            string Keyword = _Entry.Keyword;
            int UserSeq = _Entry.UserSeq;

            var Query = DatabaseContext.EventLog
                                       .AsQueryable()
                                       .GroupJoin(DatabaseContext.User, el => el.UserSeq, u => u.Seq, (el, u) => new {
                                           EventLog = el,
                                           User = u
                                       })
                                       .SelectMany(x => x.User.DefaultIfEmpty(), (el, u) => new EventLogViewModel {
                                           Seq = el.EventLog.Seq,
                                           Time = el.EventLog.Time,
                                           TimeStr = el.EventLog.Time.ToString("yyyy-MM-dd HH:mm:ss"),
                                           UserSeq = u.Seq,
                                           UserName = u.Name,
                                           Status = el.EventLog.Status,
                                           StatusStr = ""  // TODO - 事件紀錄清單，狀態
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
                Query = Query.Where(x => x.UserName.Contains(Keyword));
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
        /// 新增事件紀錄
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Set(EventLogModel _Model) {
            DatabaseContext.EventLog.Add(_Model);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除事件紀錄 (依門卡)
        /// </summary>
        /// <param name="_CardID">門卡編號</param>
        /// <returns>Task</returns>
        public async Task DeleteByCard(int _CardID = 0) {
            var Query = DatabaseContext.EventLog
                                       .AsQueryable()
                                       .Where(x => x.CardID == _CardID);

            DatabaseContext.EventLog.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }


        /// <summary>
        /// 刪除事件紀錄 (依門鎖)
        /// </summary>
        /// <param name="_DoorID">門鎖編號</param>
        /// <returns>Task</returns>
        public async Task DeleteByDoor(int _DoorID = 0) {
            var Query = DatabaseContext.EventLog
                                       .AsQueryable()
                                       .Where(x => x.DoorID == _DoorID);

            DatabaseContext.EventLog.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }


        /// <summary>
        /// 刪除事件紀錄 (依使用者)
        /// </summary>
        /// <param name="_UserSeq">使用者流水編號</param>
        /// <returns>Task</returns>
        public async Task DeleteByUser(int _UserSeq = 0) {
            var Query = DatabaseContext.EventLog
                                       .AsQueryable()
                                       .Where(x => x.UserSeq == _UserSeq);

            DatabaseContext.EventLog.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion

    }
}