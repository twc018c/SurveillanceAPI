using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener�O�P
    /// </summary>
    public class ScienerTokenModel {

        /// <summary>
        /// �s���O�P
        /// </summary>
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = "";

        /// <summary>
        /// ����O�P
        /// </summary>
        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; } = "";

        /// <summary>
        /// �O�P����
        /// </summary>
        [JsonPropertyName("tokenType")]
        public string TokenType { get; set; } = "";

        /// <summary>
        /// �Τ�D��s��
        /// </summary>
        [JsonPropertyName("uid")]
        public int UID { get; set; } = 0;

        /// <summary>
        /// ���}�s��
        /// </summary>
        [JsonPropertyName("openID")]
        public int OpenID { get; set; } = 0;

        /// <summary>
        /// �L���ɶ� (��)
        /// </summary>
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; } = 0;

        /// <summary>
        /// �v���d��
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; } = "";
    }
}