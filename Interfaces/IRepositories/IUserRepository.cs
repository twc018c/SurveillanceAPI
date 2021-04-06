using Surveillance.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 使用者
    /// </summary>
    public interface IUserRepository {

        #region "讀取"

        Task<UserModel> Get(string _Account);
        Task<(List<UserModel> List, int Count)> GetList(UserEntry _Entry);

        #endregion




        #region "新增"

        Task Set(UserModel _Model);

        #endregion




        #region "修改"

        Task Update(UserModel _Model);

        #endregion




        #region "刪除"

        Task Delete(string _Account);

        #endregion




        #region "其它"

        Task<bool> CheckAccount(string _Account);

        Task<bool> Login(UserLoginEntry _Entry);

        #endregion
    }
}