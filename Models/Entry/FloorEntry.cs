using System;


namespace Surveillance.Models {

    /// <summary>
    /// 樓層
    /// </summary>
    public class FloorEntry : Entry {

        /// <summary>
        /// 關鍵字
        /// </summary>
        public string Keyword { get; set; } = "";

        /// <summary>
        /// 層級
        /// </summary>
        public int Level { get; set; } = 0;
    }


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


    /// <summary>
    /// 樓層更新
    /// </summary>
    public class FloorUpdateEntry {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// 層級
        /// </summary>
        public int Level { get; set; } = 0;

        /// <summary>
        /// 名稱
        /// </summary>
        public string Name { get; set; } = "";
    }
}