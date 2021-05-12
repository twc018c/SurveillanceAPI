﻿using Surveillance.Models;
using System.Threading.Tasks;


namespace Surveillance.Interfaces {

    /// <summary>
    /// Sciener
    /// </summary>
    public interface IScienerService {

        #region "令牌"

        Task<ScienerTokenModel> GetToken();

        #endregion




        #region "用戶"

        Task<ScienerUserRegisterModel> RegisterUser(SicenerUserRegisterEntry _Entry);
        Task<ScienerUserListModel> GetUserList(SicenerUserEntry _Entry);

        #endregion




        #region "鎖"

        Task<ScienerLockDateModel> GetLockDate(int _LockID);
        Task<ScienerLockElectricQuantityModel> GetLockElectricQuantity(int _LockID);
        Task<ScienerLockStateModel> GetLockState(int _LockID);
        Task<ScienerLockOpenModel> LockOpen(int _LockID);
        Task<ScienerLockCloseModel> LockClose(int _LockID);
        Task<ScienerLockDetailModel> GetLockDetail(int _LockID);
        Task<ScienerLockListModel> GetLockList(SicenerLockListEntry _Entry);

        #endregion




        #region "鎖紀錄"

        Task<ScienerLockRecordModel> GetLockRecordList(SicenerLockRecordListEntry _Entry);

        #endregion




        #region "鑰匙"

        Task<ScienerKeyDetailModel> GetKeyDetail(SicenerKeyEntry _Entry);
        Task<ScienerKeyListModel> GetKeyList(SicenerKeyListEntry _Entry);

        #endregion




        #region "鍵盤密碼"

        #endregion




        #region "IC"

        #endregion

    }
}