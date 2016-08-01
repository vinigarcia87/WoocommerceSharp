namespace SharpCommerce.Data.Customers
{
    using System;

    using Newtonsoft.Json;

    public class Customer
    {
        /// <summary>
        /// Unique identifier for the resource [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// The date the customer was created, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the customer was last modified, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_modified")]
        public DateTime DateModified { get; set; }

        /// <summary>
        /// The email address for the customer [mandatory]
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Customer first name
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Customer last name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        /// Customer login name. Can be generated automatically from the customer’s email address if the option woocommerce_registration_generate_username is equal to yes [maybe mandatory] [cannot be changed]
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

        /// <summary>
        /// Customer password. Can be generated automatically with wp_generate_password() if the "Automatically generate customer password" option is enabled, check the index meta for generate_password [maybe mandatory] [write-only]
        /// </summary>
        [JsonProperty("password")]
        public string Password { get; set; }

        /// <summary>
        /// Last order data [read-only]
        /// </summary>
        [JsonProperty("last_order")]
        public LastOrder LastOrder { get; set; }

        /// <summary>
        /// Quantity of orders made by the customer [read-only]
        /// </summary>
        [JsonProperty("orders_count")]
        public int OrdersCount { get; set; }

        /// <summary>
        /// Total amount spent [read-only]
        /// </summary>
        [JsonProperty("total_spent")]
        public float TotalSpent { get; set; }

        /// <summary>
        /// Avatar URL
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }

        /// <summary>
        /// List of billing address data
        /// </summary>
        [JsonProperty("billing")]
        public BillingAddress BillingAddress { get; set; }

        /// <summary>
        /// List of shipping address data
        /// </summary>
        [JsonProperty("shipping")]
        public ShippingAddress ShippingAddress { get; set; }
    }
}
