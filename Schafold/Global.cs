namespace Surveillance.Schafold {

    /// <summary>
    /// 全域靜態類別
    /// </summary>
    public static class Global {

        /// <summary>
        /// 連線字串
        /// </summary>
        public static string ConnectionString = "";

        /// <summary>
        /// JWT金鑰
        /// </summary>
        public static string JWTSecret = "";

        /// <summary>
        /// Sciener權杖
        /// </summary>
        /// <remarks>存放最新的權杖</remarks>
        public static string ScienerAccessToken = "";

        /// <summary>
        /// Sciener編號
        /// </summary>
        public static string ScienerID = "";

        /// <summary>
        /// Sciener金鑰
        /// </summary>
        public static string ScienerSecret = "";

        /// <summary>
        /// Sciener帳號
        /// </summary>
        public static string ScienerUsername = "";

        /// <summary>
        /// Sciener密碼
        /// </summary>
        public static string ScienerPassword = "";

        /// <summary>
        /// Hangfire帳號
        /// </summary>
        public static string HangfireUsername = "";

        /// <summary>
        /// Hangfire密碼
        /// </summary>
        public static string HangfirePassword = "";
    }
}