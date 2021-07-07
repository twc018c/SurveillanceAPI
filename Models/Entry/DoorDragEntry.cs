using System;


namespace Surveillance.Models {

    /// <summary>
    /// 門鎖拖曳
    /// </summary>
    public class DoorDragEntry {

        /// <summary>
        /// 門鎖編號
        /// </summary>
        public int ID { get; set; } = 0;

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
