namespace SharpCommerce.Data.Customers
{
    using Newtonsoft.Json;
    using System;

    public class LastOrder
    {
        /// <summary>
        /// Last order ID [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// UTC DateTime of the customer last order [read-only]
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

    }
}
