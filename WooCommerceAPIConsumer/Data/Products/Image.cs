using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCommerce.Data.Products
{
    using Newtonsoft.Json;

    public class Image
    {
        /// <summary>
        /// Image ID (attachment ID). In write-mode used to attach pre-existing images
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The date the image was created, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// The date the image was last modified, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// Image URL. In write-mode you can use to send new images
        /// </summary>
        [JsonProperty("src")]
        public string Src { get; set; }

        /// <summary>
        /// Image name (attachment title) [read-only]
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Image alternative text (attachment image alt text) [read-only]
        /// </summary>
        [JsonProperty("alt")]
        public string Alt { get; set; }

        /// <summary>
        /// Image position. 0 means that the image is featured
        /// </summary>
        [JsonProperty("position")]
        public int Position { get; set; }
    }
}
