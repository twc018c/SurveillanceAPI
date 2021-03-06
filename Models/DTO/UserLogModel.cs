using Surveillance.Enums;
using System;


namespace Surveillance.Models {

    /// <summary>
    /// 使用者紀錄
    /// </summary>
    public class UserLogModel {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// 時間
        /// </summary>
        public DateTime Time { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 使用者流水編號
        /// </summary>
        public int UserSeq { get; set; } = 0;

        /// <summary>
        /// 狀態
        /// </summary>
        public USER_LOG_STATUS Status { get; set; } = USER_LOG_STATUS.UNKNOW;

        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; } = "";

        /// <summary>
        /// IP
        /// </summary>
        public string IP { get; set; } = "";
    }
}