namespace SharpCommerce.Data.Products
{
    using Newtonsoft.Json;
    using System;

    public class ProductShippingClass
    {
        /// <summary>
      /// Unique identifier for the resource [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Shipping class name [required]
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the resource unique to its type
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// HTML description of the resource
        /// </summary>
        [JsonProperty("description")]
        public int Description { get; set; }

        /// <summary>
        /// Number of published products for the resource [read-only]
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

    }
}
