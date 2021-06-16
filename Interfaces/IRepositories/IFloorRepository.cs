using Surveillance.Models;
using Surveillance.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 樓層
    /// </summary>
    public interface IFloorRepository {

        #region "讀取"

        Task<FloorModel> Get(int _Seq);
        Task<ImageModel> GetImage(int _Seq);
        Task<(List<FloorViewModel> List, int Count)> GetList(FloorListEntry _Entry);
        Task<List<SelectModel>> GetMenu();
        Task<int> GetCount();
        Task<int> GetCursor(FloorCursorEntry _Entry);

        #endregion




        #region "新增"

        Task Set(FloorModel _Model);
        Task Set(List<FloorModel> _List);

        #endregion




        #region "修改"

        Task Update(FloorModel _Model);

        #endregion




        #region "刪除"

        Task Delete(int _Seq);

        #endregion




        #region "其它"

        Task<bool> CheckLevel(int _Level);

        #endregion
    }
}