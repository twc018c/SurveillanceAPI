using Surveillance.Models;
using Surveillance.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 使用者紀錄
    /// </summary>
    public interface IUserLogRepository {

        #region "讀取"

        Task<(List<UserLogViewModel> List, int Count)> GetList(UserLogEntry _Entry);

        #endregion




        #region "新增"

        Task Set(UserLogModel _Model);

        #endregion




        #region "刪除"

        Task Delete(int _UserSeq);

        Task Delete(string _Account);

        #endregion

    }
}