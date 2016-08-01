namespace SharpCommerce.Data.Orders
{
    using System;

    using Newtonsoft.Json;

    public class OrderNote
    {
        /// <summary>
        /// Order note ID [read-only]
        /// </summary>
        [JsonProperty("id")]
        public readonly int Id;

        /// <summary>
        /// UTC DateTime when the order note was created [read-only]
        /// </summary>
        [JsonProperty("date_created")]
        public readonly DateTime DateCreated;

        /// <summary>
        /// Order note [required]
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        /// Shows/define if the note is only for reference or for the customer (the user will be notified). Default is false
        /// </summary>
        [JsonProperty("customer_note")]
        public bool CustomerNote { get; set; }        

    }
}
