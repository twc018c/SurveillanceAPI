using Surveillance.Models;
using Surveillance.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 事件紀錄
    /// </summary>
    public interface ICardBatchLogRepository {

        #region "讀取"

        Task<(List<CardBatchLogViewModel> List, int Count)> GetList(CardBatchLogListEntry _Entry);

        #endregion




        #region "新增"

        Task Set(CardBatchLogModel _Model);

        #endregion

    }
}