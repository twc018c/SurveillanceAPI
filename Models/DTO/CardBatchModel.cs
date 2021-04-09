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
        public int CardID { get; set; } = 0;

        /// <summary>
        /// 持有者編號
        /// </summary>
        /// <remarks>外部系統</remarks>
        public string HolderID { get; set; } = "";

        /// <summary>
        /// 持有者姓名
        /// </summary>
        /// <remarks>外部系統</remarks>
        public string HolderName { get; set; } = "";

        /// <summary>
        /// 允許使用開始時間
        /// </summary>
        public DateTime StartTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 允許使用結束時間
        /// </summary>
        public DateTime EndTime { get; set; } = DateTime.MinValue;
    }
}