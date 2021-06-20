using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// 門鎖批次紀錄
    /// </summary>
    public class CardBatchLogViewModel : CardBatchLogModel {

        /// <summary>
        /// 時間
        /// </summary>
        public string TimeStr { get; set; } = "";

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; } = "";
    }
}