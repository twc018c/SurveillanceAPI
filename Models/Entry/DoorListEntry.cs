using System;


namespace Surveillance.Models {

    /// <summary>
    /// 門鎖清單
    /// </summary>
    public class DoorListEntry : Entry {

        /// <summary>
        /// 關鍵字
        /// </summary>
        public string Keyword { get; set; } = "";

        /// <summary>
        /// 樓層
        /// </summary>
        public int Floor { get; set; } = 0;
    }


    /// <summary>
    /// 門鎖指標
    /// </summary>
    public class DoorCursorEntry {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// 方向
        /// </summary>
        /// <remarks>true=往下、false=往上</remarks>
        public bool Direction { get; set; } = true;
    }


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
