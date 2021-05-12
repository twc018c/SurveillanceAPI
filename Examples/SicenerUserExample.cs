using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerUserExample : IExamplesProvider<SicenerUserListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerUserListEntry</returns>
        public SicenerUserListEntry GetExamples() {
            return new SicenerUserListEntry() {
                StartDate = 0,
                EndDate = 0,
                PageNo = 1,
                PageSize = 20,
                Date = Tool.GetDateLong()
            };
        }
    }
}