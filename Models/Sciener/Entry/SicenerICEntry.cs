using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener IC卡清單
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/identityCard/list
    /// </remarks>
    public class SicenerICListEntry {

        /// <summary>
        /// 鎖編號
        /// </summary>
        public int LockID { get; set; } = 0;

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