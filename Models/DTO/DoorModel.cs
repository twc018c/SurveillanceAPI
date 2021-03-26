using System;


namespace Surveillance.Models {

    /// <summary>
    /// 門鎖
    /// </summary>
    public class DoorModel {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// 門鎖編號
        /// </summary>
        public string ID { get; set; } = "";

        /// <summary>
        /// 門鎖名稱
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 樓層
        /// </summary>
        public int Floor { get; set; } = 0;

        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; } = "";

        /// <summary>
        /// 狀態
        /// </summary>
        public int Status { get; set; } = 0;

        /// <summary>
        /// 電池電量
        /// </summary>
        public int Battery { get; set; } = 0;

        /// <summary>
        /// 遠端開鎖旗標
        /// </summary>
        public int IsRemote { get; set; } = 0;

        /// <summary>
        /// 最後動作時間
        /// </summary>
        public DateTime ActionTime { get; set; } = DateTime.MinValue;
    }
}