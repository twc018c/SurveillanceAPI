using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// 門卡
    /// </summary>
    public class CardViewModel : CardModel {

        /// <summary>
        /// 最後動作時間
        /// </summary>
        public string ActionTimeStr { get; set; } = "";
    }
}