using Surveillance.Models;


namespace Surveillance.ViewModels {

    /// <summary>
    /// ���d�妸
    /// </summary>
    public class CardBatchViewModel : CardBatchModel {

        /// <summary>
        /// ���d�Ƶ�
        /// </summary>
        public string CardNote { get; set; } = "";

        /// <summary>
        /// ���\�ϥζ}�l�ɶ�
        /// </summary>
        public string StartTimeStr { get; set; } = "";

        /// <summary>
        /// ���\�ϥε����ɶ�
        /// </summary>
        public string EndTimeStr { get; set; } = "";
    }
}