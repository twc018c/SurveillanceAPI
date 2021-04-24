using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener �Τ���U
    /// </summary>
    public class ScienerUserRegisterModel {

        /// <summary>
        /// �Τ�W
        /// </summary>
        [JsonPropertyName("username")]
        public string UserName { get; set; } = "";
    }


    /// <summary>
    /// Sciener �Τ�M��
    /// </summary>
    public class ScienerUserListModel {

        /// <summary>
        /// �M��
        /// </summary>
        [JsonPropertyName("list")]
        public List<ScienerUserModel> List { get; set; } = new List<ScienerUserModel>();

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
    /// Sciener �Τ�
    /// </summary>
    public class ScienerUserModel {

        /// <summary>
        /// �Τ�s��
        /// </summary>
        [JsonPropertyName("userid")]
        public string UserID { get; set; } = "";

        /// <summary>
        /// ���U�ɶ�
        /// </summary>
        [JsonPropertyName("regtime")]
        public long RegTime { get; set; } = 0;
    }
}