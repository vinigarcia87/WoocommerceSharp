using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCommerce.Data.Products
{
    using Newtonsoft.Json;

    public class ProductAttributeTerm
    {
        /// <summary>
        /// Unique identifier for the resource [read-only]
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Term name [required]
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the resource unique to its type
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

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
