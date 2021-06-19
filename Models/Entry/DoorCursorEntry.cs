using System;


namespace Surveillance.Models {

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
}
