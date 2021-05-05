using System.ComponentModel;


namespace Surveillance.Enums {

    /// <summary>
    /// 事件紀錄狀態
    /// </summary>
    public enum EVENT_LOG_STATUS : int {
        [Description("未知")]
        UNKNOW = 0,
        [Description("遠端開鎖")]
        OPEN = 1,
        [Description("遠端關鎖")]
        CLOSE = 2,
        [Description("門卡關鎖")]
        NEAR = 3
    }
}