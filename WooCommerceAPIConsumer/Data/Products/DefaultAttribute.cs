using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCommerce.Data.Products
{
    using Newtonsoft.Json;

    public class DefaultAttribute
    {
        /// <summary>
        /// Attribute ID (required if is a global attribute)
        /// </summary>
        [JsonProperty("id")]
        int Id { get; set; }

        /// <summary>
        /// Attribute name (required if is a non-global attribute)
        /// </summary>
        [JsonProperty("name")]
        string Name { get; set; }

        /// <summary>
        /// Selected attribute term name
        /// </summary>
        [JsonProperty("option")]
        string Option { get; set; }
    }
}
