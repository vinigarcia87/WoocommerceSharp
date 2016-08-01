namespace SharpCommerce.Data.Products
{
    using Newtonsoft.Json;

    public class ProductTag
    {

        /// <summary>
        /// Tag ID (term ID) [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Tag name [read-only]
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Tag slug
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Category description
        /// </summary>
        [JsonProperty("description")]
        public string Descripton { get; set; }

        /// <summary>
        /// Number of published products for the resource [read-only]
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

    }
}
