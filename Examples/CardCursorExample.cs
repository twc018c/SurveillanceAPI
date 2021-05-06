using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardCursorExample : IExamplesProvider<CardCursorEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardCursorEntry</returns>
        public CardCursorEntry GetExamples() {
            return new CardCursorEntry() {
                Seq = 9001,
                Direction = true
            };
        }
    }
}