namespace SharpCommerce.Data.Orders
{
    using System;

    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class Refund
    {
        /// <summary>
        /// Unique identifier for the resource [read-only]
        /// </summary>
        [JsonProperty("id")]
        public readonly int Id;

        /// <summary>
        /// The date the order refund was created, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_created")]
        public readonly DateTime DateCreated;

        /// <summary>
        /// Refund amount [required]
        /// </summary>
        [JsonProperty("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// Reason for refund
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }

        /// <summary>
        /// Line items data
        /// </summary>
        [JsonProperty("line_items")]
        public IEnumerable<LineItem> LineItems { get; set; }

    }
}
