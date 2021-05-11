using Surveillance.Library;


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
        public long Date { get; set; } = Tool.GetDateLong();
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
        public long Date { get; set; } = Tool.GetDateLong();
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
        public long Date { get; set; } = Tool.GetDateLong();
    }


    /// <summary>
    /// Sciener 鎖電量
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lock/queryElectricQuantity
    /// </remarks>
    public class SicenerLockElectricQuantityEntry {

        /// <summary>
        /// 鎖編號
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }


    /// <summary>
    /// Sciener 鎖狀態
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lock/queryOpenState
    /// </remarks>
    public class SicenerLockStateEntry {

        /// <summary>
        /// 鎖編號
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }


    /// <summary>
    /// Sciener 開鎖
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lock/lock
    /// </remarks>
    public class SicenerLockOpenEntry {

        /// <summary>
        /// 鎖編號
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }


    /// <summary>
    /// Sciener 閉鎖
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lock/unlock
    /// </remarks>
    public class SicenerLockCloseEntry {

        /// <summary>
        /// 鎖編號
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// 目前時間 (毫秒)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }


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