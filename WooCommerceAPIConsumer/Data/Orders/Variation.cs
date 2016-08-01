namespace SharpCommerce.Data.Orders
{
    using System;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;

    using SharpCommerce.Data.Downloads;
    using SharpCommerce.Data.Products;

    [DataContract]
    public class Variation
    {

        /// <summary>
        /// Variation ID (post ID) [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// UTC DateTime when the variation was created [read-only]
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// UTC DateTime when the variation was last updated [read-only]
        /// </summary>
        [JsonProperty("date_modified")]
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Variation URL (post permalink) [read-only]
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        /// <summary>
        /// Unique identifier - SKU refers to a Stock-keeping unit, a unique identifier for each distinct product and service that can be purchased
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Current variation price. This is setted from regular_price and sale_price [read-only]
        /// </summary>
        [JsonProperty("price")]
        public float Price { get; set; }

        /// <summary>
        /// Variation regular price
        /// </summary>
        [JsonProperty("regular_price")]
        public float RegularPrice { get; set; }

        /// <summary>
        /// Variation sale price
        /// </summary>
        [JsonProperty("sale_price")]
        public float SalePrice { get; set; }

        /// <summary>
        /// Sets the sale start date. Date in the YYYY-MM-DD format [write-only]
        /// </summary>
        [JsonProperty("date_on_sale_from")]
        public float SalePriceDatesFrom { get; set; }

        /// <summary>
        /// Sets the sale end date. Date in the YYYY-MM-DD format [write-only]
        /// </summary>
        [JsonProperty("date_on_sale_to")]
        public float SalePriceDatesTo { get; set; }

        /// <summary>
        /// Shows if the variation is on sale [read-only]
        /// </summary>
        [JsonProperty("on_sale")]
        public bool OnSale { get; set; }

        /// <summary>
        /// Shows if the variation can be bought [read-only]
        /// </summary>
        [JsonProperty("purchasable")]
        public bool Purchasable { get; set; }

        /// <summary>
        /// If the variation is virtual. Virtual variations are intangible and aren’t shipped. Default is false
        /// </summary>
        [JsonProperty("virtual")]
        public bool Virtual { get; set; }

        /// <summary>
        /// If the variation is downloadable. Downloadable variations give access to a file upon purchase. Default is false
        /// </summary>
        [JsonProperty("downloadable")]
        public bool Downloadable { get; set; }

        /// <summary>
        /// List of downloadable files
        /// </summary>
        [JsonProperty("downloads")]
        public DownloadableFile[] Downloads { get; set; }

        /// <summary>
        /// Amount of times the variation can be downloaded, the -1 values means unlimited re-downloads. Default is -1
        /// </summary>
        [JsonProperty("download_limit")]
        public int? DownloadLimit { get; set; }

        /// <summary>
        /// Number of days that the customer has up to be able to download the variation, the -1 means that downloads never expires. Default is -1
        /// </summary>
        [JsonProperty("download_expiry")]
        public int? DownloadExpiry { get; set; }

        /// <summary>
        /// Tax status. The options are: taxable, shipping (Shipping only) and none
        /// </summary>
        [JsonProperty("tax_status")]
        public string TaxStatus { get; set; }

        /// <summary>
        /// Tax class
        /// </summary>
        [JsonProperty("tax_class")]
        public string TaxClass { get; set; }

        /// <summary>
        /// Stock management at variation level. Default is false
        /// </summary>
        [JsonProperty("manage_stock")]
        public bool ManageStock { get; set; }

        /// <summary>
        /// Stock quantity. If is a variable variation this value will be used to control stock for all variations, unless you define stock at variation level
        /// </summary>
        [JsonProperty("stock_quantity")]
        public int StockQuantity { get; set; }

        /// <summary>
        /// Controls whether or not the variation is listed as “in stock” or “out of stock” on the frontend. Default is true
        /// </summary>
        [JsonProperty("in_stock")]
        public bool InStock { get; set; }

        /// <summary>
        /// If managing stock, this controls if backorders are allowed. If enabled, stock quantity can go below 0. Default is no. Options are: no (Do not allow), notify (Allow, but notify customer), and yes (Allow)
        /// </summary>
        private string backorders;
        [JsonProperty("backorders")]
        public string BackOrders
        {
            get
            {
                return this.backorders;
            }
            set
            {
                switch (value)
                {
                    case "yes":
                        this.backorders = value;
                        return;

                    case "no":
                        this.backorders = value;
                        return;

                    case "notify":
                        this.backorders = value;
                        return;

                    default:
                        throw new ArgumentException(
                            "Invalid value. Choices are 'yes', 'no', 'notify'");
                }
            }
        }

        /// <summary>
        /// Shows if backorders are allowed [read-only]
        /// </summary>
        [JsonProperty("backorders_allowed")]
        public bool BackordersAllowed { get; set; }

        /// <summary>
        /// Shows if a variation is on backorder (if the variation have the stock_quantity negative) [read-only]
        /// </summary>
        [JsonProperty("backordered")]
        public bool BackOrdered { get; set; }

        /// <summary>
        /// Variation weight in decimal format
        /// </summary>
        [JsonProperty("weight")]
        public float? Weight { get; set; }

        /// <summary>
        /// Variation dimensions
        /// </summary>
        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }

        /// <summary>
        /// Shipping class slug. Shipping classes are used by certain shipping methods to group similar products
        /// </summary>
        [JsonProperty("shipping_class")]
        public string ShippingClass { get; set; }

        /// <summary>
        /// Shipping class ID [read-only]
        /// </summary>
        [JsonProperty("shipping_class_id")]
        public int? ShippingClassId { get; set; }

        /// <summary>
        /// Variation featured image. Only position 0 will be used
        /// </summary>
        [JsonProperty("images")]
        public Image[] Images { get; set; }

        /// <summary>
        /// List of variation attributes
        /// </summary>
        [JsonProperty("attributes")]
        public Products.DefaultAttribute[] Attributes { get; set; }

        
    }
}
