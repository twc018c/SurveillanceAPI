using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// 使用者紀錄
    /// </summary>
    public class UserLogViewModel : UserLogModel {

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