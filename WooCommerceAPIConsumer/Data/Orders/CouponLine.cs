namespace SharpCommerce.Data.Orders
{
    using Newtonsoft.Json;

    public class CouponLine
    {
        /// <summary>
        /// Item ID [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Coupon code [required]
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Discount total [required]
        /// </summary>
        [JsonProperty("discount")]
        public float Discount { get; set; }

        /// <summary>
        /// Discount total tax [read-only]
        /// </summary>
        [JsonProperty("discount_tax")]
        public float DiscountTax { get; set; }
    }
}
