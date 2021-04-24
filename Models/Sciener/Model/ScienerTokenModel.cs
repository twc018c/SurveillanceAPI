using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener令牌
    /// </summary>
    public class ScienerTokenModel {

        /// <summary>
        /// 存取令牌
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = "";

        /// <summary>
        /// 重整令牌
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; } = "";

        /// <summary>
        /// 令牌類型
        /// </summary>
        [JsonPropertyName("tokenType")]
        public string TokenType { get; set; } = "";

        /// <summary>
        /// 用戶主鍵編號
        /// </summary>
        [JsonPropertyName("uid")]
        public int UID { get; set; } = 0;

        /// <summary>
        /// 公開編號
        /// </summary>
        [JsonPropertyName("openID")]
        public int OpenID { get; set; } = 0;

        /// <summary>
        /// 過期時間 (秒)
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; } = 0;

        /// <summary>
        /// 權限範圍
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; } = "";
    }
}