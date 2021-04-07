using Surveillance.Models;
using Surveillance.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 門卡
    /// </summary>
    public interface ICardAuthorityRepository {

        #region "讀取"

        Task<(List<CardAuthorityViewModel> List, int Count)> GetList(CardAuthorityEntry _Entry);

        #endregion




        #region "新增"

        Task Set(List<CardAuthorityModel> _List);

        #endregion




        #region "刪除"

        Task DeleteByCard(string _CardID);
        Task DeleteByDoor(string _DoorID);

        #endregion




        #region "其它"

        Task<bool> CheckAvailable(string _CardID, string _DoorID);

        #endregion
    }
}