using Surveillance.Library;
using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class SicenerKeyDetailExample : IExamplesProvider<SicenerKeyDetailEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>SicenerKeyDetailEntry</returns>
        public SicenerKeyDetailEntry GetExamples() {
            return new SicenerKeyDetailEntry() {
                LockID = 2746218,
                Date = Tool.GetDateLong()
            };
        }
    }
}