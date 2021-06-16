using Surveillance.Models;
using Surveillance.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// 門卡批次
    /// </summary>
    public interface ICardBatchRepository {

        #region "讀取"

        Task<(List<CardBatchViewModel> List, int Count)> GetList(CardBatchListEntry _Entry);

        #endregion




        #region "新增"

        Task Set(List<CardBatchModel> _List);

        #endregion




        #region "修改"

        Task Update(CardBatchModel _Model);

        #endregion




        #region "刪除"

        Task DeleteByCard(int _CardID);
        Task DeleteByHolder(string _HolderID);
        Task DeleteByTime(DateTime _StartTime, DateTime _EndTime);

        #endregion




        #region "其它"

        Task<bool> CheckAvailable(CardBatchCheckEntry _Entry);

        #endregion
    }
}