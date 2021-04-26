using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// ��ܿ��
    /// </summary>
    public class SelectModel {

        /// <summary>
        /// �ƭ�
        /// </summary>
        [JsonPropertyName("value")]
        public int Value { get; set; } = 0;

        /// <summary>
        /// ���ҦW��
        /// </summary>
        [JsonPropertyName("label")]
        public string Label { get; set; } = "";

        /// <summary>
        /// ���n���ҦW��
        /// </summary>
        [JsonPropertyName("labelSub")]
        public string LabelSub { get; set; } = "";
    }
}