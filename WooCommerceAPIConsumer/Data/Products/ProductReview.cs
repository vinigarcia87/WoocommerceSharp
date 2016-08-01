using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCommerce.Data.Products
{
    using Newtonsoft.Json;

    public class ProductReview
    {
        /// <summary>
        /// Unique identifier for the resource [read-only]
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date the review was created, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_created")]
        public string DateCreated { get; set; }

        /// <summary>
        /// Review rating (0 to 5) [read-only]
        /// </summary>
        [JsonProperty("rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Reviewer name [read-only]
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Reviewer email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Shows if the reviewer bought the product or not
        /// </summary>
        [JsonProperty("verified")]
        public bool Verified { get; set; }

    }
}
