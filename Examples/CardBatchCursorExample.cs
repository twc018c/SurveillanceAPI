using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardBatchCursorExample : IExamplesProvider<CardBatchCursorEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardBatchCursorEntry</returns>
        public CardBatchCursorEntry GetExamples() {
            return new CardBatchCursorEntry() {
                Seq = 1,
                Direction = true
            };
        }
    }
}