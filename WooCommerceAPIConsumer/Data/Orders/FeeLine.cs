namespace SharpCommerce.Data.Orders
{
    using Newtonsoft.Json;

    public class FeeLine
    {
        /// <summary>
        /// Item ID [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Fee name [required]
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Tax class [required if the fee is taxable]
        /// </summary>
        [JsonProperty("tax_class")]
        public string TaxClass { get; set; }

        /// <summary>
        /// Tax status of fee. Set to taxable if need apply taxes
        /// </summary>
        [JsonProperty("tax_status")]
        public string TaxStatus { get; set; }

        /// <summary>
        /// Line total (after discounts)
        /// </summary>
        [JsonProperty("total")]
        public float Total { get; set; }

        /// <summary>
        /// Line total tax (after discounts)
        /// </summary>
        [JsonProperty("total_tax")]
        public float TotalTax { get; set; }

        /// <summary>
        /// Line taxes with id, total and subtotal [read-only]
        /// </summary>
        [JsonProperty("taxes")]
        public TaxItem Taxes { get; set; }
    }
}
