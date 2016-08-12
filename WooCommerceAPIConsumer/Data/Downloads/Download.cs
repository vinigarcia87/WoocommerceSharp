using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCommerce.Data.Downloads
{
    using Newtonsoft.Json;

    public class Download
    {
        /// <summary>
        /// Download file URL [read-only]
        /// </summary>
        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Download ID (MD5) [read-only]
        /// </summary>
        [JsonProperty("download_id")]
        public string DownloadId { get; set; }

        /// <summary>
        /// Downloadable product ID [read-only]
        /// </summary>
        [JsonProperty("product_id")]
        public int ProductId { get; set; }

        /// <summary>
        /// Downloadable file name [read-only]
        /// </summary>
        [JsonProperty("download_name")]
        public string DownloadableFileName { get; set; }

        /// <summary>
        /// Order ID [read-only]
        /// </summary>
        [JsonProperty("order_id")]
        public int OrderId { get; set; }

        /// <summary>
        /// Order key [read-only]
        /// </summary>
        [JsonProperty("order_key")]
        public string OrderKey { get; set; }

        /// <summary>
        /// Amount of downloads remaining [read-only]
        /// </summary>
        [JsonProperty("downloads_remaining")]
        public int? DownloadsRemaining { get; set; }

        /// <summary>
        /// The date when the download access expires, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("access_expires")]
        public DateTime? AccessExpires { get; set; }

        /// <summary>
        /// File details with name (file name) and file (file URL) attributes [read-only]
        /// </summary>
        [JsonProperty("file")]
        public DownloadableFile[] File { get; set; }
    }
}
