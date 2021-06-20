using System;


namespace Surveillance.Models {

    /// <summary>
    /// 門卡批次紀錄
    /// </summary>
    public class CardBatchLogModel {

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
        /// 備註
        /// </summary>
        public string Note { get; set; } = "";
    }
}