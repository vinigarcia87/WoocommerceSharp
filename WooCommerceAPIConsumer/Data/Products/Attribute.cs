using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCommerce.Data.Products
{
    using Newtonsoft.Json;

    public class Attribute
    {
        /// <summary>
        /// Attribute ID (required if is a global attribute)
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Attribute name (required if is a non-global attribute)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Attribute position
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }

        /// <summary>
        /// Define if the attribute is visible on the “Additional Information” tab in the product’s page. Default is false
        /// </summary>
        [JsonProperty("visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Define if the attribute can be used as variation. Default is false
        /// </summary>
        [JsonProperty("variation")]
        public bool Variation { get; set; }

        /// <summary>
        /// List of available term names of the attribute
        /// </summary>
        [JsonProperty("options")]
        public string[] Options { get; set; }
    }
}
