using System;


namespace Surveillance.Models {

    /// <summary>
    /// 事件紀錄
    /// </summary>
    public class EventLogEntry : Entry {

        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 結束時間
        /// </summary>
        public DateTime EndTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 關鍵字
        /// </summary>
        public string Keyword { get; set; } = "";

        /// <summary>
        /// 使用者流水編號
        /// </summary>
        public int UserSeq { get; set; } = 0;
    }
}
