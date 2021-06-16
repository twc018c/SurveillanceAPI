using System;


namespace Surveillance.Models {

    /// <summary>
    /// 門卡批次清單
    /// </summary>
    public class CardBatchListEntry : Entry {

        /// <summary>
        /// 關鍵字
        /// </summary>
        public string Keyword { get; set; } = "";

        /// <summary>
        /// 開始時間
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 時間時間
        /// </summary>
        public DateTime EndTime { get; set; } = DateTime.MinValue;
    }
}
