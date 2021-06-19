namespace Surveillance.Models {

    /// <summary>
    /// 使用者指標
    /// </summary>
    public class UserCursorEntry {

        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; } = "";

        /// <summary>
        /// 方向
        /// </summary>
        /// <remarks>true=往下、false=往上</remarks>
        public bool Direction { get; set; } = true;
    }
}
