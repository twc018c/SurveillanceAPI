using Microsoft.EntityFrameworkCore;
using Surveillance.Enums;
using Surveillance.Interfaces;
using Surveillance.Library;
using Surveillance.Models;
using Surveillance.ViewModels;
using Surveillance.Schafold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Surveillance.Repositories {

    /// <summary>
    /// 使用者紀錄
    /// </summary>
    public class UserLogRepository : IUserLogRepository {

        private DatabaseContext DatabaseContext;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DatabaseContext">資料庫上下文</param>
        public UserLogRepository(DatabaseContext _DatabaseContext) {
            DatabaseContext = _DatabaseContext;
        }


        #region "讀取"

        /// <summary>
        /// 取得使用者紀錄清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(List<UserLogViewModel> List, int Count)> GetList(UserLogListEntry _Entry) {
            int PageNow = _Entry.PageNow;
            int PageShow = _Entry.PageShow;
            DateTime StartTime = _Entry.StartTime;
            DateTime EndTime = _Entry.EndTime;
            int UserSeq = _Entry.UserSeq;
            USER_LOG_STATUS Status = _Entry.Status;

            var Query = DatabaseContext.UserLog
                                       .AsQueryable()
                                       .GroupJoin(DatabaseContext.User, ul => ul.UserSeq, u => u.Seq, (ul, u) => new {
                                           UserLog = ul,
                                           User = u
                                       })
                                       .SelectMany(x => x.User.DefaultIfEmpty(), (ul, u) => new UserLogViewModel {
                                           // Model
                                           Seq = ul.UserLog.Seq,
                                           Time = ul.UserLog.Time,
                                           UserSeq = (u == null) ? 0 : u.Seq,
                                           Status = ul.UserLog.Status,
                                           Note = ul.UserLog.Note,
                                           IP = ul.UserLog.IP,
                                           // ViewModel
                                           TimeStr = ul.UserLog.Time.ToString("yyyy-MM-dd HH:mm:ss"),
                                           UserName = u.Name ?? "",
                                           StatusStr = ul.UserLog.Status.ToEnumDescription()
                                       });

            // 開始時間
            if (StartTime != DateTime.MinValue) {
                Query = Query.Where(x => x.Time >= StartTime);
            }

            // 結束時間
            if (EndTime != DateTime.MinValue) {
                Query = Query.Where(x => x.Time <= EndTime);
            }

            // 使用者流水編號
            if (UserSeq > 0) {
                Query = Query.Where(x => x.UserSeq == UserSeq);
            }

            // 狀態
            if (Status != USER_LOG_STATUS.UNKNOW) {
                Query = Query.Where(x => x.Status == Status);
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
        /// 新增使用者紀錄
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Set(UserLogModel _Model) {
            if (_Model.Time == DateTime.MinValue) {
                _Model.Time = DateTime.Now;
            }

            DatabaseContext.UserLog.Add(_Model);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除使用者紀錄
        /// </summary>
        /// <param name="_UserSeq">使用者流水編號</param>
        /// <returns>Task</returns>
        public async Task Delete(int _UserSeq = 0) {
            var Query = DatabaseContext.UserLog
                                       .AsQueryable()
                                       .Where(x => x.UserSeq == _UserSeq);

            DatabaseContext.UserLog.RemoveRange(Query);

            await DatabaseContext.SaveChangesAsync();
        }


        /// <summary>
        /// 刪除使用者紀錄
        /// </summary>
        /// <param name="_Account">使用者帳號</param>
        /// <returns>Task</returns>
        public async Task Delete(string _Account = "") {
            // 使用者流水編號
            int UserSeq = await DatabaseContext.User.AsQueryable()
                                                    .Where(x => x.Account == _Account)
                                                    .Select(x => x.Seq)
                                                    .FirstOrDefaultAsync();

            // 刪除使用者紀錄
            await Delete(UserSeq);
        }

        #endregion

    }
}