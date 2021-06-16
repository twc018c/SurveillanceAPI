using Surveillance.Models;
using Surveillance.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 門卡權限
    /// </summary>
    public interface ICardAuthorityRepository {

        #region "讀取"

        Task<(List<CardAuthorityViewModel> List, int Count)> GetList(CardAuthorityListEntry _Entry);

        #endregion




        #region "新增"

        Task Set(List<CardAuthorityModel> _List);

        #endregion




        #region "刪除"

        Task DeleteByCard(int _CardID);
        Task DeleteByDoor(int _DoorID);

        #endregion




        #region "其它"

        Task<bool> Check(CardAuthorityCheckEntry _Entry);

        #endregion
    }
}