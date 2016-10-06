namespace SharpCommerce.Data.Orders
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ShippingLine
    {
        /// <summary>
        /// Item ID [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Shipping method name
        /// </summary>
        [JsonProperty("method_title")]
        public string MethodTitle { get; set; }

        /// <summary>
        /// Shipping method ID [required]
        /// </summary>
        [JsonProperty("method_id")]
        public string MethodId { get; set; }

        /// <summary>
        /// Line total (after discounts)
        /// </summary>
        [JsonProperty("total")]
        public float Total { get; set; }

        /// <summary>
        /// Line total tax (after discounts) [read-only]
        /// </summary>
        [JsonProperty("total_tax")]
        public float TotalTax { get; set; }

        /// <summary>
        /// Line taxes with id and total [read-only]
        /// </summary>
        [JsonProperty("taxes")]
        public IEnumerable<TaxItem> Taxes { get; set; }
    }
}
