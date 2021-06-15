using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class FloorCursorExample : IExamplesProvider<FloorCursorEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>FloorCursorEntry</returns>
        public FloorCursorEntry GetExamples() {
            return new FloorCursorEntry() {
                Seq = 1,
                Direction = true
            };
        }
    }
}