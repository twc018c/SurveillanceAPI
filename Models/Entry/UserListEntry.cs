namespace Surveillance.Models {

    /// <summary>
    /// 使用者清單
    /// </summary>
    public class UserListEntry : Entry {

        /// <summary>
        /// 關鍵字
        /// </summary>
        public string Keyword { get; set; } = "";
    }


    /// <summary>
    /// 使用者密碼
    /// </summary>
    public class UserPasswordEntry {

        /// <summary>
        /// 帳號
        /// </summary>
        public string Account { get; set; } = "";

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; } = "";
    }
    
    
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
