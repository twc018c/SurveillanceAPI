using System;


namespace Surveillance.Models {

    /// <summary>
    /// 門鎖更新
    /// </summary>
    public class DoorUpdateEntry {

        /// <summary>
        /// 門鎖編號
        /// </summary>
        public int ID { get; set; } = 0;

        /// <summary>
        /// 門鎖名稱
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; } = "";

        /// <summary>
        /// 電量
        /// </summary>
        public int Battery { get; set; } = 0;

        /// <summary>
        /// 電量更新時間
        /// </summary>
        public DateTime BatteryTime { get; set; } = DateTime.MinValue;
    }
}
