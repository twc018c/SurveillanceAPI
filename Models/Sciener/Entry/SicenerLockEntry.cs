namespace Surveillance.Models {

    /// <summary>
    /// Sciener ��M��
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lock/list
    /// </remarks>
    public class SicenerLockListEntry {

        /// <summary>
        /// ��O�W
        /// </summary>
        /// <remarks>
        /// ���
        /// </remarks>
        public string LockAlias { get; set; } = "";

        /// <summary>
        /// �]������
        /// </summary>
        /// <remarks>
        /// ���
        /// 1=��
        /// 2=�豱
        /// </remarks>
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


    /// <summary>
    /// Sciener ��Բ�
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lock/detail
    /// </remarks>
    public class SicenerLockDetailEntry {

        /// <summary>
        /// ��s��
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = 0;
    }


    /// <summary>
    /// Sciener ��ɶ�
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/lock/queryDate
    /// </remarks>
    public class SicenerLockDateEntry {

        /// <summary>
        /// ��s��
        /// </summary>
        public int LockID { get; set; } = 0;

        /// <summary>
        /// �ثe�ɶ� (�@��)
        /// </summary>
        public long Date { get; set; } = 0;
    }
}