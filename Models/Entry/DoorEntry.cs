namespace Surveillance.Models {

    /// <summary>
    /// 門鎖
    /// </summary>
    public class DoorEntry : Entry {

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
    /// 門鎖
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
