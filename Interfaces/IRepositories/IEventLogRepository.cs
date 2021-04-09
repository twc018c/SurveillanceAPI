using Surveillance.Models;
using Surveillance.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 事件紀錄
    /// </summary>
    public interface IEventLogRepository {

        #region "讀取"

        Task<(List<EventLogViewModel> List, int Count)> GetList(EventLogEntry _Entry);

        #endregion




        #region "新增"

        Task Set(EventLogModel _Model);

        #endregion




        #region "刪除"

        Task DeleteByCard(int _CardID);
        Task DeleteByDoor(int _DoorID);
        Task DeleteByUser(int _UserSeq);

        #endregion

    }
}