using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// 事件紀錄
    /// </summary>
    public class EventLogViewModel : EventLogModel {

        /// <summary>
        /// 時間
        /// </summary>
        public string TimeStr { get; set; } = "";

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; } = "";

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusStr { get; set; } = "";
    }
}