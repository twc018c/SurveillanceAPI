using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// ����
    /// </summary>
    public class DoorViewModel : DoorModel {

        /// <summary>
        /// �̫�ʧ@�ɶ�
        /// </summary>
        public string ActionTimeStr { get; set; } = "";

        /// <summary>
        /// ���A
        /// </summary>
        public string StatusStr { get; set; } = "";
    }
}