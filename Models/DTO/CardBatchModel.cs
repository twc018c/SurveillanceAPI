using System;


namespace Surveillance.Models {

    /// <summary>
    /// 門卡批次
    /// </summary>
    public class CardBatchModel {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// 門卡編號
        /// </summary>
        public string CardID { get; set; } = "";

        /// <summary>
        /// 持有者名稱
        /// </summary>
        public string Name { get; set; } = "";

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