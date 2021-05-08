using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener �}������M��
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lockRecord/list
    /// </remarks>
    public class SicenerLockRecordListEntry {

        /// <summary>
        /// ��s��
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// �}�l�ɶ�
        /// </summary>
        /// <remarks>
        /// ���A0=�L����
        /// </remarks>
        public long StartDate { get; set; } = 0;

        /// <summary>
        /// �����ɶ�
        /// </summary>
        /// <remarks>
        /// ���A0=�L����
        /// </remarks>
        public long EndDate { get; set; } = 0;

        /// <summary>
        /// ���X
        /// </summary>
        public int PageNo { get; set; } = 0;

        /// <summary>
        /// �C���ƶq
        /// </summary>
        public int PageSize { get; set; } = 0;

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = Tool.GetDateLong();
    }
}