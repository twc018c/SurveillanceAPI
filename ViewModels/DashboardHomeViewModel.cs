using System;


namespace Surveillance.ViewModels {

    /// <summary>
    /// 儀錶板首頁
    /// </summary>
    public class DashboardHomeViewModel {

        /// <summary>
        /// 門卡數量
        /// </summary>
        public int CountCard { get; set; } = 0;

        /// <summary>
        /// 門鎖
        /// </summary>
        public int CountDoor { get; set; } = 0;

        /// <summary>
        /// 使用者
        /// </summary>
        public int CountUser { get; set; } = 0;
    }
}