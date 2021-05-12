using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener �����M��
    /// </summary>
    public class SicenerFingerprintListEntry {

        /// <summary>
        /// ��s��
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// ���X
        /// </summary>
        public int PageNo { get; set; } = 1;

        /// <summary>
        /// �C���ƶq
        /// </summary>
        public int PageSize { get; set; } = 100;

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }
}