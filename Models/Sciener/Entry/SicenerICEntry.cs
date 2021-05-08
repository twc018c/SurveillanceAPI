using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener IC�d�M��
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/identityCard/list
    /// </remarks>
    public class SicenerICListEntry {

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
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }
}