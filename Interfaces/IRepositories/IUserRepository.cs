using Surveillance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 使用者
    /// </summary>
    public interface IUserRepository {

        #region "讀取"

        Task<List<UserModel>> GetList();

        #endregion
    }
}