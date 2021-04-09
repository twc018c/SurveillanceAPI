using System;


namespace Surveillance.Models {

    /// <summary>
    /// 門卡
    /// </summary>
    public class CardModel {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// 門卡編號
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; } = "";

        /// <summary>
        /// 啟用旗標
        /// </summary>
        public int IsWork { get; set; } = 0;

        /// <summary>
        /// 最後動作時間
        /// </summary>
        public DateTime ActionTime { get; set; } = DateTime.MinValue;
    }
}