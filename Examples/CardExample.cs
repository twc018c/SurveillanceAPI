using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardExample : IExamplesProvider<CardEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardEntry</returns>
        public CardEntry GetExamples() {
            return new CardEntry() {
                Keyword = ""
            };
        }
    }
}