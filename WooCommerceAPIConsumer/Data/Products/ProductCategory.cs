namespace SharpCommerce.Data.Products
{
    using Newtonsoft.Json;

    public class ProductCategory
    {

        /// <summary>
        /// Category ID (term ID) [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Category name [read-only]
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Category slug
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Category parent [read-only]
        /// </summary>
        [JsonProperty("parent")]
        public int Parent { get; set; }

        /// <summary>
        /// Category description
        /// </summary>
        [JsonProperty("description")]
        public string Descripton { get; set; }

        /// <summary>
        /// Category archive display type. Default is default. Options: default, products, subcategories and both
        /// </summary>
        [JsonProperty("display")]
        public string Display { get; set; }

        /// <summary>
        /// Category Image data
        /// </summary>
        [JsonProperty("image")]
        public Image Image { get; set; }

        /// <summary>
        /// Menu order, used to custom sort the resource 
        /// </summary>
        [JsonProperty("menu_order")]
        public int MenuOrder { get; set; }

        /// <summary>
        /// Number of published products for the resource [read-only]
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }

    }
}
