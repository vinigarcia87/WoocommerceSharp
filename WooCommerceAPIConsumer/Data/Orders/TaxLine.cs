namespace SharpCommerce.Data.Orders
{
    using Newtonsoft.Json;

    public class TaxLine
    {
        /// <summary>
        /// Item ID [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Tax rate code [read-only]
        /// </summary>
        [JsonProperty("rate_code")]
        public string RateCode { get; set; }

        /// <summary>
        /// Tax rate ID [read-only]
        /// </summary>
        [JsonProperty("rate_id")]
        public int RateId { get; set; }

        /// <summary>
        /// Tax rate label [read-only]
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Show if is a compound tax rate. Compound tax rates are applied on top of other tax rates [read-only]
        /// </summary>
        [JsonProperty("compound")]
        public bool Compound { get; set; }

        /// <summary>
        /// Tax total (not including shipping taxes) [read-only]
        /// </summary>
        [JsonProperty("tax_total")]
        public float TaxTotal { get; set; }

        /// <summary>
        /// Shipping tax total [read-only]
        /// </summary>
        [JsonProperty("shipping_tax_total")]
        public string ShippingTaxTotal { get; set; }
    }
}
