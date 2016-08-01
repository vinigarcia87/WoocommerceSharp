namespace SharpCommerce.Data.Orders
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class LineItem
    {

        /// <summary>
        /// Item ID [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Product name [read-only]
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Product SKU [read-only]
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Product ID
        /// </summary>
        [JsonProperty("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Variation ID, if applicable
        /// </summary>
        [JsonProperty("variation_id")]
        public int VariationId { get; set; }

        /// <summary>
        /// Quantity ordered
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Tax class of product [read-only]
        /// </summary>
        [JsonProperty("tax_class")]
        public string TaxClass { get; set; }

        /// <summary>
        /// Product price [read-only]
        /// </summary>
        [JsonProperty("price")]
        public float Price { get; set; }

        /// <summary>
        /// Line subtotal (before discounts)
        /// </summary>
        [JsonProperty("subtotal")]
        public float Subtotal { get; set; }

        /// <summary>
        /// Line subtotal tax (before discounts)
        /// </summary>
        [JsonProperty("subtotal_tax")]
        public float SubtotalTax { get; set; }

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
        public IEnumerable<TaxItem> Taxes { get; set; }

        /// <summary>
        /// Line item meta data with key, label and value [read-only]
        /// </summary>
        [JsonProperty("meta")]
        public IEnumerable<MetaItem> Meta { get; set; }


    }
}
