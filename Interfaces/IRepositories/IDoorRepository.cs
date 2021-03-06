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

        Task<DoorModel> Get(int _Seq);
        Task<(List<DoorViewModel> List, int Count)> GetList(DoorListEntry _Entry);
        Task<List<DoorDragViewModel>> GetDragList(int _FloorLevel);
        Task<int> GetCount();
        Task<int> GetCursor(DoorCursorEntry _Entry);

        #endregion




        #region "新增"

        Task Set(DoorModel _Model);
        Task Set(List<DoorModel> _List);

        #endregion




        #region "修改"

        Task Update(DoorModel _Model);
        Task Update(DoorUpdateEntry _Model);
        Task Update(List<DoorUpdateEntry> _List);
        Task Drag(DoorDragEntry _Entry);

        #endregion




        #region "刪除"

        Task Delete(int _ID);
        Task Delete(List<int> _List);

        #endregion




        #region "其它"

        Task<bool> CheckID(int _ID);

        #endregion
    }
}