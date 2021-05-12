using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener 鑰匙內容
    /// </summary>
    public class ScienerKeyDetailEntry {

        /// <summary>
        /// 鑰匙編號
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }


    /// <summary>
    /// Sciener 鑰匙清單
    /// </summary>
    public class ScienerKeyListEntry {

        /// <summary>
        /// 鎖別名
        /// </summary>
        /// <remarks>
        /// 選填
        /// </remarks>
        public string LockAlias { get; set; } = "";

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
        public long Date { get; set; } = Tool.GetDateLong();
    }
}