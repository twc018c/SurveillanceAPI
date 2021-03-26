using System.ComponentModel;


namespace Surveillance.Enums {

    /// <summary>
    /// API回應代碼
    /// </summary>
    public enum API_RESULT_CODE : int {
        [Description("資料庫錯誤")]
        DB_ERROR = -99,
        [Description("筆數限制")]
        LIMIT = -2,
        [Description("參數錯誤")]
        PARA_ERROR = -1,
        [Description("未知")]
        UNKNOW = 0,
        [Description("成功")]
        SUCCESS = 1
    }
}