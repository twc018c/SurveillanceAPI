using Surveillance.Enums;


namespace Surveillance.Models {

    /// <summary>
    /// API
    /// </summary>
    public class APIModel {

        /// <summary>
        /// 內容
        /// </summary>
        public object Result { get; set; } = null;

        /// <summary>
        /// 數量
        /// </summary>
        public int ResultCount { get; set; } = 0;

        /// <summary>
        /// 回應代碼
        /// </summary>
        public API_RESULT_CODE ResultCode { get; set; } = API_RESULT_CODE.UNKNOW;

        /// <summary>
        /// 回應訊息
        /// </summary>
        public string ResultMessage { get; set; } = "";
    }
}