using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCommerce.Data.Products
{
    using Newtonsoft.Json;

    public class Dimensions
    {

        /// <summary>
        /// Product length in decimal format
        /// </summary>
        [JsonProperty("length")]
        public string Length { get; set; }

        /// <summary>
        /// Product width in decimal format
        /// </summary>
        [JsonProperty("width")]
        public string Width { get; set; }

        /// <summary>
        /// Product height in decimal format
        /// </summary>
        [JsonProperty("height")]
        public string Height { get; set; }

    }
}
