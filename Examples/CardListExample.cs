using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardListExample : IExamplesProvider<CardListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardEntry</returns>
        public CardListEntry GetExamples() {
            return new CardListEntry() {
                Keyword = ""
            };
        }
    }
}