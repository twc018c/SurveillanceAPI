using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// �ϥΪ̬���
    /// </summary>
    public class UserLogViewModel : UserLogModel {

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