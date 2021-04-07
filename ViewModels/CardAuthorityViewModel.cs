using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// 門卡權限
    /// </summary>
    public class CardAuthorityViewModel : CardAuthorityModel {

        /// <summary>
        /// 門卡備註
        /// </summary>
        public string CardNote { get; set; } = "";

        /// <summary>
        /// 門鎖名稱
        /// </summary>
        public string DoorName { get; set; } = "";
    }
}