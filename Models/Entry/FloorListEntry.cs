namespace Surveillance.Models {

    /// <summary>
    /// 樓層清單
    /// </summary>
    public class FloorListEntry : Entry {

        /// <summary>
        /// 關鍵字
        /// </summary>
        public string Keyword { get; set; } = "";

        /// <summary>
        /// 層級
        /// </summary>
        public int Level { get; set; } = 0;

        /// <summary>
        /// 圖片旗標
        /// </summary>
        public bool FlagImage { get; set; } = false;
    }
}