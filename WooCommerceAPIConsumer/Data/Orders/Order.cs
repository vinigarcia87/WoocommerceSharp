namespace SharpCommerce.Data.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;

    using SharpCommerce.Data.Customers;
    using Newtonsoft.Json.Converters;


    [DataContract]
    public class Order
    {

        // Default values for some.
        private string status = "pending";

        /// <summary>
        /// Unique identifier for the resource [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Parent order ID
        /// </summary>
        [JsonProperty("parent_id")]
        public int ParentId { get; set; }

        /// <summary>
        /// Order status. Default is pending. Options: pending, processing, on-hold, completed, cancelled, refunded and failed
        /// </summary>
        [JsonProperty("status")]
        public string Status
        {
            get
            {
                return this.status;
            }
            set
            {
                switch (value)
                {
                    case "pending":
                        this.status = value;
                        return;

                    case "processing":
                        this.status = value;
                        return;

                    case "on-hold":
                        this.status = value;
                        return;

                    case "completed":
                        this.status = value;
                        return;

                    case "cancelled":
                        this.status = value;
                        return;

                    case "refunded":
                        this.status = value;
                        return;

                    case "failed":
                        this.status = value;
                        return;

                    default:
                        throw new ArgumentException(
                            "Invalid product type. Choices are 'pending', 'processing', 'on-hold', 'completed', 'cancelled', 'refunded', 'failed'");
                }
            }
        }

        /// <summary>
        /// Order key [read-only]
        /// </summary>
        [JsonProperty("order_key")]
        public string OrderKey { get; set; }

        /// <summary>
        /// Order number [read-only]
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }

        /// <summary>
        /// Currency the order was created with, in ISO format, e.g USD. Default is the current store currency
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Version of WooCommerce when the order was made [read-only]
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; set; }

        /// <summary>
        /// Shows if the prices included tax during checkout [read-only]
        /// </summary>
        [JsonProperty("prices_include_tax")]
        public bool PricesIncludeTax { get; set; }

        /// <summary>
        /// The date the order was created, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the order was last modified, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_modified")]
        public DateTime DateModified { get; set; }

        /// <summary>
        /// User ID who owns the order. Use 0 for guests. Default is 0
        /// </summary>
        [JsonProperty("customer_id")]
        public int CustomerId { get; set; }

        /// <summary>
        /// Total discount amount for the order [read-only]
        /// </summary>
        [JsonProperty("discount_total")]
        public string DiscountTotal { get; set; }

        /// <summary>
        /// Total discount tax amount for the order [read-only]
        /// </summary>
        [JsonProperty("discount_tax")]
        public string DiscountTax { get; set; }

        /// <summary>
        /// Total shipping amount for the order [read-only]
        /// </summary>
        [JsonProperty("shipping_total")]
        public string ShippingTotal { get; set; }

        /// <summary>
        /// Total shipping tax amount for the order [read-only]
        /// </summary>
        [JsonProperty("shipping_tax")]
        public string ShippingTax { get; set; }

        /// <summary>
        /// Sum of line item taxes only [read-only]
        /// </summary>
        [JsonProperty("cart_tax")]
        public string CartTax { get; set; }

        /// <summary>
        /// Grand total [read-only]
        /// </summary>
        [JsonProperty("total")]
        public string Total { get; set; }

        /// <summary>
        /// Sum of all taxes [read-only]
        /// </summary>
        [JsonProperty("total_tax")]
        public string TotalTax { get; set; }

        /// <summary>
        /// Billing address
        /// </summary>
        [JsonProperty("billing")]
        public BillingAddress BillingAddress { get; set; }

        /// <summary>
        /// Shipping address
        /// </summary>
        [JsonProperty("shipping")]
        public ShippingAddress ShippingAddress { get; set; }

        /// <summary>
        /// Payment method ID
        /// </summary>
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }

        /// <summary>
        /// Payment method title
        /// </summary>
        [JsonProperty("payment_method_title")]
        public string PaymentMethodTitle { get; set; }

        /// <summary>
        /// Define if the order is paid. It will set the status to processing and reduce stock items. Default is false [write-only]
        /// </summary>
        [JsonProperty("set_paid")]
        public bool SetPaid { get; set; }

        /// <summary>
        /// Unique transaction ID. In write-mode only is available if set_paid is true
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// Customer’s IP address [read-only]
        /// </summary>
        [JsonProperty("customer_ip_address")]
        public string CustomerIpAddress { get; set; }

        /// <summary>
        /// User agent of the customer [read-only]
        /// </summary>
        [JsonProperty("customer_user_agent")]
        public string CustomerUserAgent { get; set; }

        /// <summary>
        /// Shows where the order was created [read-only]
        /// </summary>
        [JsonProperty("created_via")]
        public string CreatedVia { get; set; }

        /// <summary>
        /// Note left by customer during checkout [read-only]
        /// </summary>
        [JsonProperty("customer_note")]
        public string CustomerNote { get; set; }

        /// <summary>
        /// The date the order was completed, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_completed")]
        public DateTime DateCompleted { get; set; }

        /// <summary>
        /// The date the order has been paid, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_paid")]
        public DateTime? DatePaid { get; set; }

        /// <summary>
        /// MD5 hash of cart items to ensure orders are not modified [read-only]
        /// </summary>
        [JsonProperty("cart_hash")]
        public string CartHash { get; set; }

        /// <summary>
        /// Line items data
        /// </summary>
        [JsonProperty("line_items")]
        public IEnumerable<LineItem> LineItems { get; set; }

        /// <summary>
        /// Tax lines data [read-only]
        /// </summary>
        [JsonProperty("tax_lines")]
        public IEnumerable<TaxLine> TaxLines { get; set; }

        /// <summary>
        /// Shipping lines data
        /// </summary>
        [JsonProperty("shipping_lines")]
        public IEnumerable<ShippingLine> ShippingLines { get; set; }

        /// <summary>
        /// Fee lines data
        /// </summary>
        [JsonProperty("fee_lines")]
        public IEnumerable<FeeLine> FeeLines { get; set; }

        /// <summary>
        /// Coupons line data
        /// </summary>
        [JsonProperty("coupon_lines")]
        public IEnumerable<CouponLine> CouponLines { get; set; }

    }
}
