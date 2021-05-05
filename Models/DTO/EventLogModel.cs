using Surveillance.Enums;
using System;


namespace Surveillance.Models {

    /// <summary>
    /// 事件紀錄
    /// </summary>
    public class EventLogModel {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// 時間
        /// </summary>
        public DateTime Time { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 門鎖編號
        /// </summary>
        public int DoorID { get; set; } = 0;

        /// <summary>
        /// 門卡編號
        /// </summary>
        public int CardID { get; set; } = 0;

        /// <summary>
        /// 狀態
        /// </summary>
        public EVENT_LOG_STATUS Status { get; set; } = EVENT_LOG_STATUS.UNKNOW;

        /// <summary>
        /// 使用者流水編號
        /// </summary>
        public int UserSeq { get; set; } = 0;
    }
}