using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener Token
    /// </summary>
    public class ScienerTokenModel {

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("tokenType")]
        public string TokenType { get; set; } = "";

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("uid")]
        public int UID { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("openID")]
        public int OpenID { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; } = 0;

        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; } = "";
    }
}