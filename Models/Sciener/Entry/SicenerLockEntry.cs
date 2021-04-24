namespace Surveillance.Models {

    /// <summary>
    /// Sciener ��M��
    /// </summary>
    public class SicenerLockListEntry {

        /// <summary>
        /// ��O�W
        /// </summary>
        public string LockAlias { get; set; } = "";

        /// <summary>
        /// �]������
        /// </summary>
        public int Type { get; set; } = 1;

        /// <summary>
        /// ���X
        /// </summary>
        public int PageNo { get; set; } = 1;

        /// <summary>
        /// �C���ƶq
        /// </summary>
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = 0;
    }
}