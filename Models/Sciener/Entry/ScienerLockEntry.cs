using Surveillance.Enums;
using Surveillance.Library;


namespace Surveillance.Models {

    /// <summary>
    /// Sciener ��M��
    /// </summary>
    public class ScienerLockListEntry {

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
        /// </remarks>
        public SCIENER_DEVICE_TYPE Type { get; set; } = SCIENER_DEVICE_TYPE.LOCK;

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


    /// <summary>
    /// Sciener �}������M��
    /// </summary>
    public class ScienerLockRecordListEntry {

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