using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// ����
    /// </summary>
    public class DoorViewModel : DoorModel {

        /// <summary>
        /// �q�q��s�ɶ�
        /// </summary>
        public string BatteryTimeStr { get; set; } = "";

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