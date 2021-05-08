using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerUserExample : IExamplesProvider<SicenerUserEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerUserEntry</returns>
        public SicenerUserEntry GetExamples() {
            return new SicenerUserEntry() {
                StartDate = 0,
                EndDate = 0,
                PageNo = 1,
                PageSize = 20,
                Date = Tool.GetDateLong()
            };
        }
    }
}