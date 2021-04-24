using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener �����M��
    /// </summary>
    public class ScienerGatewayListModel {

        /// <summary>
        /// �M��
        /// </summary>
        [JsonPropertyName("list")]
        public List<ScienerGatewayModel> List { get; set; } = new List<ScienerGatewayModel>();

        /// <summary>
        /// ���X
        /// </summary>
        [JsonPropertyName("pageNo")]
        public int PageNo { get; set; } = 0;

        /// <summary>
        /// �C���ƶq
        /// </summary>
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; } = 0;

        /// <summary>
        /// �`����
        /// </summary>
        [JsonPropertyName("pages")]
        public int Pages { get; set; } = 0;

        /// <summary>
        /// �`��
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; } = 0;
    }


    /// <summary>
    /// Sciener ����
    /// </summary>
    public class ScienerGatewayModel {

        /// <summary>
        /// �����s��
        /// </summary>
        [JsonPropertyName("gatewayId")]
        public int GatewayID { get; set; } = 0;

        /// <summary>
        /// ����MAC�a�}
        /// </summary>
        [JsonPropertyName("gatewayMac")]
        public string GatewayMAC { get; set; } = "";

        /// <summary>
        /// ����������
        /// </summary>
        [JsonPropertyName("gatewayVersion")]
        public int GatewayVersion { get; set; } = 0;

        /// <summary>
        /// �s�������������W��
        /// </summary>
        [JsonPropertyName("networkName")]
        public string NetworkName { get; set; } = "";

        /// <summary>
        /// �����޲z����ƶq
        /// </summary>
        [JsonPropertyName("lockNum")]
        public int LockNum { get; set; } = 0;

        /// <summary>
        /// �O�_�b�u
        /// </summary>
        [JsonPropertyName("isOnline")]
        public int IsOnline { get; set; } = 0;
    }
}