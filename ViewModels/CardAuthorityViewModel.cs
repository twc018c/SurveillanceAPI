using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// ���d�v��
    /// </summary>
    public class CardAuthorityViewModel : CardAuthorityModel {

        /// <summary>
        /// ���d�Ƶ�
        /// </summary>
        public string CardNote { get; set; } = "";

        /// <summary>
        /// ����W��
        /// </summary>
        public string DoorName { get; set; } = "";
    }
}