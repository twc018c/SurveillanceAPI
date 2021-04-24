namespace Surveillance.Models {

    /// <summary>
    /// Sciener 鎖清單
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lock/list
    /// </remarks>
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
        public long Date { get; set; } = 0;
    }


    /// <summary>
    /// Sciener 鎖詳細
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lock/detail
    /// </remarks>
    public class SicenerLockDetailEntry {

        /// <summary>
        /// 鎖編號
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = 0;
    }


    /// <summary>
    /// Sciener 鎖時間
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lock/queryDate
    /// </remarks>
    public class SicenerLockDateEntry {

        /// <summary>
        /// 鎖編號
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = 0;
    }
}