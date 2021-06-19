namespace Surveillance.Models {

    /// <summary>
    /// 樓層指標
    /// </summary>
    public class FloorCursorEntry {

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