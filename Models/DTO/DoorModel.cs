using Surveillance.Enums;
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
        public int ID { get; set; } = 0;

        /// <summary>
        /// 門鎖名稱
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 樓層層級
        /// </summary>
        public int FloorLevel { get; set; } = 0;

        /// <summary>
        /// 備註
        /// </summary>
        public string Note { get; set; } = "";

        /// <summary>
        /// 狀態
        /// </summary>
        public SCIENER_LOCK_STATE Status { get; set; } = SCIENER_LOCK_STATE.UNKNOW;

        /// <summary>
        /// 電量
        /// </summary>
        public int Battery { get; set; } = 0;

        /// <summary>
        /// 電量更新時間
        /// </summary>
        public DateTime BatteryTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 遠端開鎖旗標
        /// </summary>
        public int IsRemote { get; set; } = 0;

        /// <summary>
        /// 最後動作時間
        /// </summary>
        public DateTime ActionTime { get; set; } = DateTime.MinValue;

        /// <summary>
        /// 圖案X位置
        /// </summary>
        /// <remarks>百分比，小數2位</remarks>
        public decimal PositionX { get; set; } = 0M;

        /// <summary>
        /// 圖案Y位置
        /// </summary>
        /// <remarks>百分比，小數2位</remarks>
        public decimal PositionY { get; set; } = 0M;
    }
}