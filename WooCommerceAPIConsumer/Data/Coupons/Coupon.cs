using System;

namespace SharpCommerce.Data.Coupons
{
    using System.Globalization;

    using Newtonsoft.Json;

    public class Coupon
    {
        private string type = "fixed_cart";

        /// <summary>
        /// Unique identifier for the object [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Coupon code [mandatory]
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// The date the coupon was created, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// The date the coupon was last modified, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_modified")]
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Coupon description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Determines the type of discount that will be applied. Options: fixed_cart, percent, fixed_product and percent_product. Default: fixed_cart
        /// </summary>
        [JsonProperty("discount_type")]
        public string DiscountType
        {
            get
            {
                return this.type;
            }
            set
            {
                
                switch (value)
                {
                    case "fixed_cart":
                        this.type = value;
                        return;

                    case "percent":
                        this.type = value;
                        return;

                    case "fixed_product":
                        this.type = value;
                        return;

                    case "percent_product":
                        this.type = value;
                        return;

                    default:
                        throw new ArgumentException("Invalid coupon type. Choices are 'fixed_cart', 'percent', 'fixed_product' and 'percent_product'.");
                }
            }
        }

        /// <summary>
        /// The amount of discount
        /// </summary>
        [JsonProperty("amount")]
        public float Amount { get; set; }

        /// <summary>
        /// UTC DateTime when the coupon expires
        /// </summary>
        [JsonProperty("expiry_date")]
        public DateTime? ExpiryDate { get; set; }

        /// <summary>
        /// Number of times the coupon has been used already [read-only]
        /// </summary>
        [JsonProperty("usage_count")]
        public int UsageCount { get; set; }

        /// <summary>
        /// Whether coupon can only be used individually
        /// </summary>
        [JsonProperty("individual_use")]
        public bool IndividualUse { get; set; }

        /// <summary>
        /// List of product ID’s the coupon can be used on
        /// </summary>
        [JsonProperty("product_ids")]
        public int[] ProductIds { get; set; }

        /// <summary>
        /// List of product ID’s the coupon cannot be used on
        /// </summary>
        [JsonProperty("exclude_product_ids")]
        public int[] ExcludeProductIds { get; set; }

        /// <summary>
        /// How many times the coupon can be used
        /// </summary>
        [JsonProperty("usage_limit")]
        public int? UsageLimit { get; set; }

        /// <summary>
        /// How many times the coupon can be used per customer
        /// </summary>
        [JsonProperty("usage_limit_per_user")]
        public int? UsageLimitPerUser { get; set; }

        /// <summary>
        /// Max number of items in the cart the coupon can be applied to
        /// </summary>
        [JsonProperty("limit_usage_to_x_items")]
        public int? LimitUsageToXItems { get; set; }

        /// <summary>
        /// Define if can be applied for free shipping
        /// </summary>
        [JsonProperty("free_shipping")]
        public bool FreeShipping { get; set; }

        /// <summary>
        /// List of category ID’s the coupon applies to
        /// </summary>
        [JsonProperty("product_categories")]
        public int[] ProductCategoryIds { get; set; }

        /// <summary>
        /// List of category ID’s the coupon does not apply to
        /// </summary>
        [JsonProperty("excluded_product_categories")]
        public int[] ExcludedProductCategoryIds { get; set; }

        /// <summary>
        /// Define if should not apply when have sale items
        /// </summary>
        [JsonProperty("exclude_sale_items")]
        public bool ExcludeSaleItems { get; set; }

        /// <summary>
        /// Minimum order amount that needs to be in the cart before coupon applies
        /// </summary>
        [JsonProperty("minimum_amount")]
        public float MinimumAmount { get; set; }

        /// <summary>
        /// Maximum order amount allowed when using the coupon
        /// </summary>
        [JsonProperty("maximum_amount")]
        public float MaximumAmount { get; set; }

        /// <summary>
        /// List of email addresses that can use this coupon
        /// </summary>
        [JsonProperty("email_restrictions")]
        public string[] CustomerEmails { get; set; }

        /// <summary>
        /// List of user IDs who have used the coupon [read-only]
        /// </summary>
        [JsonProperty("used_by")]
        public string[] UsedBy { get; set; }
    }
}
