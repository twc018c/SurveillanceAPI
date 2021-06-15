using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class FloorExample : IExamplesProvider<FloorEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>FloorEntry</returns>
        public FloorEntry GetExamples() {
            return new FloorEntry() {
                Keyword = "",
                Level = 0
            };
        }
    }
}