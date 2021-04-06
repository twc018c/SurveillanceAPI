namespace Surveillance.Models {

    /// <summary>
    /// 基底
    /// </summary>
    public class Entry {

        /// <summary>
        /// 目前頁碼
        /// </summary>
        public int PageNow { get; set; } = 1;

        /// <summary>
        /// 每頁筆數
        /// </summary>
        public int PageShow { get; set; } = 50;
    }
}
