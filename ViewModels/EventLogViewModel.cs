using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// �ƥ����
    /// </summary>
    public class EventLogViewModel : EventLogModel {

        /// <summary>
        /// �ɶ�
        /// </summary>
        public string TimeStr { get; set; } = "";

        /// <summary>
        /// �ϥΪ̦W��
        /// </summary>
        public string UserName { get; set; } = "";

        /// <summary>
        /// ���A
        /// </summary>
        public string StatusStr { get; set; } = "";
    }
}