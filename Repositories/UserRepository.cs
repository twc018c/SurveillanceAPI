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
            if (!string.IsNullOrEmpty(_Entry.Keyword)) {
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

        #endregion




        #region "新增"

        /// <summary>
        /// 新增使用者
        /// </summary>
        /// <param name="_Model">模型</param>
        /// <returns>Task</returns>
        public async Task Set(UserModel _Model) {
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
                DatabaseContext.Entry(Temp).CurrentValues.SetValues(_Model);

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
    }
}