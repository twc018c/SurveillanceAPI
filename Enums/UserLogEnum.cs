using System.ComponentModel;


namespace Surveillance.Enums {

    /// <summary>
    /// 使用者紀錄狀態
    /// </summary>
    public enum USER_LOG_STATUS : int {
        [Description("未知")]
        UNKNOW = 0,
        [Description("登入")]
        LOGIN = 1,
        [Description("登出")]
        LOGOUT = 2
    }
}