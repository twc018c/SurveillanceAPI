using System;


namespace Surveillance.Models {

    /// <summary>
    /// 使用者
    /// </summary>
    public class UserModel {

        /// <summary>
        /// 流水編號
        /// </summary>
        public int Seq { get; set; } = 0;

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; } = "";

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; } = "";

        /// <summary>
        /// 管理員旗標
        /// </summary>
        public byte IsAdmin { get; set; } = 0;

        /// <summary>
        /// 啟用旗標
        /// </summary>
        public byte IsWork { get; set; } = 0;

        /// <summary>
        /// 最後動作時間
        /// </summary>
        public DateTime ActionTime { get; set; } = DateTime.MinValue;
    }
}