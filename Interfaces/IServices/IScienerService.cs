using Surveillance.Models;
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

        Task<ScienerUserRegisterModel> RegisterUser(ScienerUserRegisterEntry _Entry);
        Task<ScienerUserListModel> GetUserList(ScienerUserListEntry _Entry);

        #endregion




        #region "鎖"

        Task<ScienerLockDateModel> GetLockDate(int _LockID);
        Task<ScienerLockElectricQuantityModel> GetLockElectricQuantity(int _LockID);
        Task<ScienerLockStateModel> GetLockState(int _LockID);
        Task<ScienerLockOpenModel> LockOpen(int _LockID);
        Task<ScienerLockCloseModel> LockClose(int _LockID);
        Task<ScienerLockDetailModel> GetLockDetail(int _LockID);
        Task<ScienerLockListModel> GetLockList(ScienerLockListEntry _Entry);

        #endregion




        #region "鎖紀錄"

        Task<ScienerLockRecordModel> GetLockRecordList(ScienerLockRecordListEntry _Entry);

        #endregion




        #region "鑰匙"

        Task<ScienerKeyDetailModel> GetKeyDetail(ScienerKeyDetailEntry _Entry);
        Task<ScienerKeyListModel> GetKeyList(ScienerKeyListEntry _Entry);

        #endregion




        #region "鍵盤密碼"

        #endregion




        #region "IC"

        #endregion




        #region "指紋"

        #endregion




        #region "網關"

        #endregion

    }
}