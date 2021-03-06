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
        /// 樓層層級
        /// </summary>
        public int FloorLevel { get; set; } = 0;
    }
}
