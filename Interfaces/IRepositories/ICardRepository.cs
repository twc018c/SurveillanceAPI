using Surveillance.Models;
using Surveillance.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 門卡
    /// </summary>
    public interface ICardRepository {

        #region "讀取"

        Task<(List<CardViewModel> List, int Count)> GetList(CardEntry _Entry);

        #endregion




        #region "新增"

        Task Set(CardModel _Model);

        #endregion




        #region "修改"

        Task Update(CardModel _Model);

        #endregion




        #region "刪除"

        Task Delete(int _ID);

        #endregion




        #region "其它"

        Task<bool> CheckID(int _ID);

        #endregion
    }
}