namespace Surveillance.Models {

    /// <summary>
    /// Sciener �����M��
    /// </summary>
    /// <remarks>
    /// https://open.sciener.com/doc/api/v3/gateway/list
    /// </remarks>
    public class SicenerGatewayListEntry {

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