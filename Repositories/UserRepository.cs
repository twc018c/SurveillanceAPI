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

        private MySQLContext MySQLContext;


        /// <summary>
        /// 建構
        /// </summary>
        /// <param name="_MySQLContext"></param>
        public UserRepository(MySQLContext _MySQLContext) {
            MySQLContext = _MySQLContext;
        }


        #region "讀取"

        /// <summary>
        /// 取得使用者清單
        /// </summary>
        /// <returns>List</returns>
        public async Task<List<UserModel>> GetList() {
            return await MySQLContext.User.AsQueryable().ToListAsync();
        }

        #endregion
    }
}