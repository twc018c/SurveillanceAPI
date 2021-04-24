namespace Surveillance.Models {

    /// <summary>
    /// Sciener 鑰匙清單
    /// </summary>
    public class SicenerKeyListEntry {

        /// <summary>
        /// 鎖別名
        /// </summary>
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
        public long Date { get; set; } = 0;
    }
}