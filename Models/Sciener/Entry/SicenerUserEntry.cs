namespace Surveillance.Models {

    /// <summary>
    /// Sciener 用戶註冊
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/user/register
    /// </remarks>
    public class SicenerUserRegisterEntry {

        /// <summary>
        /// 用戶名
        /// </summary>
        public string UserName { get; set; } = "";

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = 0;
    }


    /// <summary>
    /// Sciener 用戶清單
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/user/list
    /// </remarks>
    public class SicenerUserEntry {

        /// <summary>
        /// 開始時間
        /// </summary>
        /// <remarks>
        /// 0=無限制
        /// </remarks>
        public long StartDate { get; set; } = 0;

        /// <summary>
        /// 結束時間
        /// </summary>
        /// <remarks>
        /// 0=無限制
        /// </remarks>
        public long EndDate { get; set; } = 0;

        /// <summary>
        /// 頁碼
        /// </summary>
        public int PageNo { get; set; } = 1;

        /// <summary>
        /// 每頁數量
        /// </summary>
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = 0;
    }
}