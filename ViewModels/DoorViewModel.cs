using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// 門鎖
    /// </summary>
    public class DoorViewModel : DoorModel {

        /// <summary>
        /// 電量更新時間
        /// </summary>
        public string BatteryTimeStr { get; set; } = "";

        /// <summary>
        /// 最後動作時間
        /// </summary>
        public string ActionTimeStr { get; set; } = "";

        /// <summary>
        /// 狀態
        /// </summary>
        public string StatusStr { get; set; } = "";
    }
}