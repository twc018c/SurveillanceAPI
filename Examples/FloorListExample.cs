using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class FloorListExample : IExamplesProvider<FloorListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>FloorEntry</returns>
        public FloorListEntry GetExamples() {
            return new FloorListEntry() {
                PageNow = 1,
                PageShow = 20,
                Keyword = "",
                Level = 0,
                FlagImage = false
            };
        }
    }
}