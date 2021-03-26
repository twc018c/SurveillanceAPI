namespace Surveillance.Models {

    /// <summary>
    /// 門卡權限
    /// </summary>
    public class CardAuthorityModel {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

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