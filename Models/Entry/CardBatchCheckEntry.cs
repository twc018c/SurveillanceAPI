using System;


namespace Surveillance.Models {

    /// <summary>
    /// 門卡批次檢查
    /// </summary>
    public class CardBatchCheckEntry {

        /// <summary>
        /// 門卡編號
        /// </summary>
        public string CardID { get; set; } = "";

        /// <summary>
        /// 持有者編號
        /// </summary>
        public string HolderID { get; set; } = "";

        /// <summary>
        /// 時間
        /// </summary>
        public DateTime Time { get; set; } = DateTime.MinValue;
    }
}
