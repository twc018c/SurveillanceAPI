using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener 鑰匙清單
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/key/list
    /// </remarks>
    public class SicenerKeyListEntry {

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
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }
}