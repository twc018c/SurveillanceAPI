using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener 鎖清單
    /// </summary>
    public class SicenerLockListEntry {

        /// <summary>
        /// 鎖別名
        /// </summary>
        /// <remarks>
        /// 選填
        /// </remarks>
        public string LockAlias { get; set; } = "";

        /// <summary>
        /// 設備類型
        /// </summary>
        /// <remarks>
        /// 選填
        /// 1=鎖
        /// 2=梯控
        /// </remarks>
        public int Type { get; set; } = 1;

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


    /// <summary>
    /// Sciener 開鎖紀錄清單
    /// </summary>
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