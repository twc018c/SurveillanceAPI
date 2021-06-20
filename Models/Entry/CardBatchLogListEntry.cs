using System;


namespace Surveillance.Models {

    /// <summary>
    /// 門卡批次紀錄清單
    /// </summary>
    public class CardBatchLogListEntry : Entry {

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
