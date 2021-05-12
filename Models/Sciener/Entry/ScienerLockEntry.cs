using Surveillance.Enums;
using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener 鎖清單
    /// </summary>
    public class ScienerLockListEntry {

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
        /// </remarks>
        public SCIENER_DEVICE_TYPE Type { get; set; } = SCIENER_DEVICE_TYPE.LOCK;

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


    /// <summary>
    /// Sciener 開鎖紀錄清單
    /// </summary>
    public class ScienerLockRecordListEntry {

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