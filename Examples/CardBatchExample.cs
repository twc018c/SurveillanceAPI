using Surveillance.Models;
using Swashbuckle.AspNetCore.Filters;
using System;


namespace Surveillance.Examples {

    /// <summary>
    /// 模型範例
    /// </summary>
    public class CardBatchExample : IExamplesProvider<CardBatchEntry> {

        /// <summary>
        /// 建構
        /// </summary>
        /// <returns>CardBatchEntry</returns>
        public CardBatchEntry GetExamples() {
            return new CardBatchEntry() {
                Keyword = "",
                StartTime = new DateTime(2021, 01, 01),
                EndTime = new DateTime(2021, 12, 31)
            };
        }
    }
}