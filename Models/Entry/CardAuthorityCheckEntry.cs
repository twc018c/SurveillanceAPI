namespace Surveillance.Models {

    /// <summary>
    /// 門卡權限檢查
    /// </summary>
    public class CardAuthorityCheckEntry {

        /// <summary>
        /// 門鎖編號
        /// </summary>
        public string DoorID { get; set; } = "";

        /// <summary>
        /// 門卡編號
        /// </summary>
        public string CardID { get; set; } = "";
    }
}
