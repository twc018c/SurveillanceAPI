using Microsoft.EntityFrameworkCore;
using Surveillance.Interfaces;
using Surveillance.Models;
using Surveillance.Schafold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Surveillance.Repositories {

    /// <summary>
    /// 使用者
    /// </summary>
    public class UserRepository : IUserRepository {

        private DatabaseContext DatabaseContext;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_DatabaseContext">資料庫上下文</param>
        public UserRepository(DatabaseContext _DatabaseContext) {
            DatabaseContext = _DatabaseContext;
        }


        #region "讀取"

        /// <summary>
        /// 取得使用者
        /// </summary>
        /// <param name="_Account">帳號</param>
        /// <returns>UserModel</returns>
        public async Task<UserModel> Get(string _Account = "") {
            var Model =  await DatabaseContext.User
                                              .AsQueryable()
                                              .Where(x => x.Account == _Account)
                                              .FirstOrDefaultAsync();
            
            if (Model == null) {
                Model = new UserModel();
            } else {
                // 不顯示密碼
                Model.Password = string.Empty;
            }

            return Model;
        }


        /// <summary>
        /// 取得使用者清單
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(List<UserModel> List, int Count)> GetList(UserEntry _Entry) {
            int PageNow = _Entry.PageNow;
            int PageShow = _Entry.PageShow;
            string Keyword = _Entry.Keyword;

            var Query = DatabaseContext.User.AsQueryable();

            // 關鍵字
            if (!string.IsNullOrEmpty(Keyword)) {
                Query = Query.Where(x => x.Account.Contains(Keyword) || x.Name.Contains(Keyword));
            }

            int Count = await Query.CountAsync();

            var List = await Query.Skip((PageNow - 1) * PageShow)
                                  .Take(PageShow)
                                  .ToListAsync();

            List.ForEach(x => {
                // 不顯示密碼
                x.Password = string.Empty;
            });

            return (List, Count);
        }


        /// <summary>
        /// 取得使用者選單
        /// </summary>
        /// <returns>List</returns>
        public async Task<List<SelectModel>> GetMenu() {
            List<SelectModel> List = new List<SelectModel>();

            var Query = DatabaseContext.User.AsQueryable();

            await Query.OrderBy(x => x.Seq).ForEachAsync(x => {
                List.Add(new SelectModel() {
                    Value = (int)x.Seq,
                    Label = x.Name
                });
            });

            return List;
        }


        /// <summary>
        /// 取得使用者數量
        /// </summary>
        /// <returns>int</returns>
        public async Task<int> GetCount() {
            return await DatabaseContext.User.AsQueryable().CountAsync();
        }


        /// <summary>
        /// 取得使用者指標
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>string</returns>
        public async Task<string> GetCursor(UserCursorEntry _Entry) {
            string Account = string.Empty;
            UserModel Model = new UserModel();

            var Query = DatabaseContext.User.AsQueryable();

            // 流水編號
            int Seq = await Query.Where(x => x.Account == _Entry.Account)
                                 .Select(x => x.Seq)
                                 .FirstOrDefaultAsync();

            if (_Entry.Direction) {
                Model = Query.Where(x => x.Seq > Seq)
                             .OrderBy(x => x.Seq)
                             .FirstOrDefault();
            } else {
                Model = Query.Where(x => x.Seq < Seq)
                             .OrderByDescending(x => x.Seq)
                             .FirstOrDefault();
            }

            if (Model != null) {
                Account = Model.Account;
            }

            return Account;
        }

        #endregion




        #region "新增"

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Set(UserModel _Model) {
            // 最後動作時間
            _Model.ActionTime = DateTime.Now;

            DatabaseContext.User.Add(_Model);

            await DatabaseContext.SaveChangesAsync();
        }

        #endregion




        #region "修改"

        /// <summary>
        /// 修改使用者
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Update(UserModel _Model) {
            var Temp = await DatabaseContext.User.SingleAsync(x => x.Account == _Model.Account);

            if (Temp != null) {
                Temp.Name = _Model.Name;
                Temp.Password = _Model.Password;
                Temp.ActionTime = DateTime.Now;
                Temp.IsWork = _Model.IsWork;

                await DatabaseContext.SaveChangesAsync();
            }
        }


        /// <summary>
        /// 修改使用者密碼
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Task</returns>
        public async Task UpdatePassword(UserPasswordEntry _Entry) {
            var Temp = await DatabaseContext.User.SingleAsync(x => x.Account == _Entry.Account);

            if (Temp != null) {
                Temp.Password = _Entry.Password;

                await DatabaseContext.SaveChangesAsync();
            }
        }


        /// <summary>
        /// 修改使用者IP
        /// </summary>
        /// <param name="_Account">帳號</param>
        /// <param name="_IP">IP</param>
        /// <returns>Task</returns>
        public async Task UpdateIP(string _Account, string _IP) {
            var Temp = await DatabaseContext.User.SingleAsync(x => x.Account == _Account);

            if (Temp != null) {
                Temp.IP = _IP;

                await DatabaseContext.SaveChangesAsync();
            }
        }

        #endregion




        #region "刪除"

        /// <summary>
        /// 刪除使用者
        /// </summary>
        /// <param name="_Account">帳號</param>
        /// <returns>Task</returns>
        public async Task Delete(string _Account = "") {
            var Temp = await DatabaseContext.User.SingleAsync(x => x.Account == _Account);

            if (Temp != null) {
                DatabaseContext.User.Remove(Temp);

                await DatabaseContext.SaveChangesAsync();
            }
        }

        #endregion




        #region "其它"

        /// <summary>
        /// 檢查使用者帳號
        /// </summary>
        /// <param name="_Account">帳號</param>
        /// <returns>bool</returns>
        public async Task<bool> CheckAccount(string _Account = "") {
            bool Flag = false;

            var Model = await DatabaseContext.User
                                             .AsQueryable()
                                             .AsNoTracking()
                                             .Where(x => x.Account == _Account)
                                             .FirstOrDefaultAsync();

            if (Model != null) {
                Flag = true;
            }

            return Flag;
        }


        /// <summary>
        /// 使用者登入
        /// </summary>
        /// <param name="_Entry">模型</param>
        /// <returns>Tuple</returns>
        public async Task<(bool Flag, UserModel Model)> Login(UserLoginEntry _Entry) {
            bool Flag = false;

            var Model = await DatabaseContext.User
                                             .AsQueryable()
                                             .AsNoTracking()
                                             .Where(x => x.Account == _Entry.Account && x.Password == _Entry.Password)
                                             .FirstOrDefaultAsync();

            if (Model != null) {
                Flag = true;

                Model.IP = _Entry.IP;

                // 修改使用者IP
                await UpdateIP(_Entry.Account, _Entry.IP);
            }

            return (Flag, Model);
        }

        #endregion
    }
}