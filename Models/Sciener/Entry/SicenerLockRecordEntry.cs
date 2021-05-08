using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener 開鎖紀錄清單
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lockRecord/list
    /// </remarks>
    public class SicenerLockRecordListEntry {

        /// <summary>
        /// 鎖編號
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// 開始時間
        /// </summary>
        /// <remarks>
        /// 選填，0=無限制
        /// </remarks>
        public long StartDate { get; set; } = 0;

        /// <summary>
        /// 結束時間
        /// </summary>
        /// <remarks>
        /// 選填，0=無限制
        /// </remarks>
        public long EndDate { get; set; } = 0;

        /// <summary>
        /// 頁碼
        /// </summary>
        public int PageNo { get; set; } = 0;

        /// <summary>
        /// 每頁數量
        /// </summary>
        public int PageSize { get; set; } = 0;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }
}