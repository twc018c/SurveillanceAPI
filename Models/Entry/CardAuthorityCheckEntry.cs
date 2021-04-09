namespace Surveillance.Models {

    /// <summary>
    /// 門卡權限檢查
    /// </summary>
    public class CardAuthorityCheckEntry {

        /// <summary>
        /// 門鎖編號
        /// </summary>
        public int DoorID { get; set; } = 0;

        /// <summary>
        /// 門卡編號
        /// </summary>
        public int CardID { get; set; } = 0;
    }
}
