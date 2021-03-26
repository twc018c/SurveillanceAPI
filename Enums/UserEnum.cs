using System.ComponentModel;


namespace Surveillance.Enums {

    /// <summary>
    /// 使用者紀錄狀態
    /// </summary>
    public enum USER_LOG_STATUS : int {
        [Description("")]
        UNKNOW = 0,
        [Description("")]
        LOGIN = 1,
        [Description("")]
        LOGOUT = 2
    }
}