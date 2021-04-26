using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// 選擇選單
    /// </summary>
    public class SelectModel {

        /// <summary>
        /// 數值
        /// </summary>
        [JsonPropertyName("value")]
        public int Value { get; set; } = 0;

        /// <summary>
        /// 標籤名稱
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; } = "";

        /// <summary>
        /// 次要標籤名稱
        /// </summary>
        [JsonPropertyName("labelSub")]
        public string LabelSub { get; set; } = "";
    }
}