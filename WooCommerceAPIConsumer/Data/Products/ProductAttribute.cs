using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCommerce.Data.Products
{
    using Newtonsoft.Json;

    public class ProductAttribute
    {
        /// <summary>
        /// Attribute ID [read-only]
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Attribute name [required]
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An alphanumeric identifier for the resource unique to its type
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Type of attribute. Default is select. Options: select and text (some plugins can include new types)
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Default sort order. Default is menu_order. Options: menu_order, name, name_num and id
        /// </summary>
        [JsonProperty("order_by")]
        public string OrderBy { get; set; }

        /// <summary>
        /// Enable/Disable attribute archives. Default is false
        /// </summary>
        [JsonProperty("has_archives")]
        public bool HasArchives { get; set; }
    }
}
