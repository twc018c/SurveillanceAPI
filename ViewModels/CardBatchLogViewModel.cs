using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// ����妸����
    /// </summary>
    public class CardBatchLogViewModel : CardBatchLogModel {

        /// <summary>
        /// �ɶ�
        /// </summary>
        public string TimeStr { get; set; } = "";

        /// <summary>
        /// �ϥΪ̦W��
        /// </summary>
        public string UserName { get; set; } = "";
    }
}