using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener 用戶註冊
    /// </summary>
    public class ScienerUserRegisterEntry {

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
        public long Date { get; set; } = Tool.GenerateDateLong();
    }


    /// <summary>
    /// Sciener 用戶清單
    /// </summary>
    public class ScienerUserListEntry {

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
        public int PageSize { get; set; } = 100;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = Tool.GenerateDateLong();
    }
}