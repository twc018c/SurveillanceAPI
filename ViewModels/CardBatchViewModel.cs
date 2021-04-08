using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// 門卡批次
    /// </summary>
    public class CardBatchViewModel : CardBatchModel {

        /// <summary>
        /// 門卡備註
        /// </summary>
        public string CardNote { get; set; } = "";

        /// <summary>
        /// 允許使用開始時間
        /// </summary>
        public string StartTimeStr { get; set; } = "";

        /// <summary>
        /// 允許使用結束時間
        /// </summary>
        public string EndTimeStr { get; set; } = "";
    }
}