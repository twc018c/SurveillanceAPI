using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;
using System;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardBatchListExample : IExamplesProvider<CardBatchListEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardBatchEntry</returns>
        public CardBatchListEntry GetExamples() {
            return new CardBatchListEntry() {
                Keyword = "",
                StartTime = new DateTime(2021, 01, 01),
                EndTime = new DateTime(2021, 12, 31)
            };
        }
    }
}