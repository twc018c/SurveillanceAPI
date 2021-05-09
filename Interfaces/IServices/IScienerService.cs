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

        Task<ScienerUserRegisterModel> RegisterUser(SicenerUserRegisterEntry _Entry);
        Task<ScienerUserListModel> GetUserList(SicenerUserEntry _Entry);

        #endregion




        #region "鎖"

        Task<ScienerLockDateModel> GetLockDate(int _LockID);
        Task<ScienerLockDetailModel> GetLockDetail(int _LockID);
        Task<ScienerLockListModel> GetLockList(SicenerLockListEntry _Entry);

        #endregion




        #region "鑰匙"

        #endregion




        #region "鍵盤密碼"

        #endregion




        #region "IC"

        #endregion




        #region "鎖紀錄"

        #endregion

    }
}