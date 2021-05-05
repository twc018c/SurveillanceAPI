using Surveillance.Enums;
using System;


namespace Surveillance.Models {

    /// <summary>
    /// 使用者紀錄
    /// </summary>
    public class UserLogEntry : Entry {

        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime EndTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 使用者流水編號
        /// </summary>
        public int UserSeq { get; set; } = 0;

        /// <summary>
        /// 狀態
        /// </summary>
        public USER_LOG_STATUS Status { get; set; } = USER_LOG_STATUS.UNKNOW;
    }
}
