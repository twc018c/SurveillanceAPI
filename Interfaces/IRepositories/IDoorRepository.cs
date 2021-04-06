using Surveillance.Models;
using Surveillance.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 門鎖
    /// </summary>
    public interface IDoorRepository {

        #region "讀取"

        Task<(List<DoorViewModel> List, int Count)> GetList(DoorEntry _Entry);

        #endregion




        #region "新增"

        Task Set(DoorModel _Model);

        #endregion




        #region "刪除"

        Task Delete(string _ID);

        #endregion




        #region "其它"

        Task<bool> CheckID(string _ID);

        #endregion
    }
}