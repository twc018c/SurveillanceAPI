using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardAuthorityListExample : IExamplesProvider<CardAuthorityListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardAuthorityEntry</returns>
        public CardAuthorityListEntry GetExamples() {
            return new CardAuthorityListEntry() {
                Keyword = ""
            };
        }
    }
}