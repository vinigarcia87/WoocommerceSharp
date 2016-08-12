using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpCommerce.Data.Products
{
    using System.Net.Mime;

    using Newtonsoft.Json;

    using SharpCommerce.Data.Downloads;
    using SharpCommerce.Data.Orders;

    public class Product
    {
        // Default values for some
        private string type = "simple";
        private string status = "publish";
        private string catalogvisibility = "visible";
        private string downloadtype = "standard";
        private string taxstatus = "taxable";
        private string backorders = "no";

        /// <summary>
        /// Product ID (post ID) [read-only]
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Product slug
        /// </summary>
        [JsonProperty("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Product URL (post permalink) [read-only]
        /// </summary>
        [JsonProperty("permalink")]
        public string Permalink { get; set; }

        /// <summary>
        /// The date the product was created, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// The date the product was last modified, in the site’s timezone [read-only]
        /// </summary>
        [JsonProperty("date_modified")]
        public DateTime? DateModified { get; set; }

        /// <summary>
        /// Product type. Default is simple. Options: simple, grouped, external, variable
        /// </summary>
        [JsonProperty("type")]
        public string Type
        {
            get
            {
                return this.type;
            }
            set
            {
                switch (value)
                {
                    case "simple":
                        this.type = value;
                        return;

                    case "grouped":
                        this.type = value;
                        return;

                    case "external":
                        this.type = value;
                        return;

                    case "variable":
                        this.type = value;
                        return;

                    default:
                        throw new ArgumentException(
                            "Invalid product type. Choices are 'simple', 'grouped', 'external' and 'variable'");
                }
            }
        }

        /// <summary>
        /// Product status (post status). Default is publish. Options: draft, pending, private and publish
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
                    case "draft":
                        this.status = value;
                        return;

                    case "pending":
                        this.status = value;
                        return;

                    case "private":
                        this.status = value;
                        return;

                    case "publish":
                        this.status = value;
                        return;

                    default:
                        throw new ArgumentException(
                            "Invalid product status. Choices are 'draft', 'pending', 'private', 'publish'");
                }
            }
        }

        /// <summary>
        /// Featured product. Default is false
        /// </summary>
        [JsonProperty("featured")]
        public bool Featured { get; set; }
        
        /// <summary>
        /// Catalog visibility. Default is visible. Options: visible (Catalog and search), catalog (Only in catalog), search (Only in search) and hidden (Hidden from all)
        /// </summary>
        [JsonProperty("catalog_visibility")]
        public string CatalogVisibility
        {
            get
            {
                return this.catalogvisibility;
            }
            set
            {
                switch (value)
                {
                    case "visible":
                        this.catalogvisibility = value;
                        return;

                    case "catalog":
                        this.catalogvisibility = value;
                        return;

                    case "search":
                        this.catalogvisibility = value;
                        return;

                    case "hidden":
                        this.catalogvisibility = value;
                        return;

                    default:
                        throw new ArgumentException("Invalid catalog visibility value. Choices are 'visible', 'catalog', 'search', 'hidden'");
                }
            }
        }

        /// <summary>
        /// Product description
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Product short description
        /// </summary>
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Unique identifier - SKU refers to a Stock-keeping unit, a unique identifier for each distinct product and service that can be purchased
        /// </summary>
        [JsonProperty("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Current product price. This is setted from regular_price and sale_price [read-only]
        /// </summary>
        [JsonProperty("price")]
        public float Price { get; set; }

        /// <summary>
        /// Product regular price
        /// </summary>
        [JsonProperty("regular_price")]
        public string RegularPrice { get; set; }

        /// <summary>
        /// Product sale price
        /// </summary>
        [JsonProperty("sale_price")]
        public string SalePrice { get; set; }

        /// <summary>
        /// Start date of sale price. Date in the YYYY-MM-DD format
        /// </summary>
        [JsonProperty("date_on_sale_from")]
        public string SalePriceDatesFrom { get; set; }

        /// <summary>
        /// Sets the sale end date. Date in the YYYY-MM-DD format
        /// </summary>
        [JsonProperty("date_on_sale_to")]
        public string SalePriceDatesTo { get; set; }

        /// <summary>
        /// Price formatted in HTML, e.g. <del><span class=\"woocommerce-Price-amount amount\"><span class=\"woocommerce-Price-currencySymbol\">&#36;&nbsp;3.00</span></span></del> <ins><span class=\"woocommerce-Price-amount amount\"><span class=\"woocommerce-Price-currencySymbol\">&#36;&nbsp;2.00</span></span></ins> [read-only]
        /// </summary>
        [JsonProperty("price_html")]
        public string PriceHtml { get; set; }

        /// <summary>
        /// Shows if the product is on sale [read-only]
        /// </summary>
        [JsonProperty("on_sale")]
        public bool OnSale { get; set; }

        /// <summary>
        /// Shows if the product can be bought [read-only]
        /// </summary>
        [JsonProperty("purchasable")]
        public bool Purchasable { get; set; }

        /// <summary>
        /// Amount of sales [read-only]
        /// </summary>
        [JsonProperty("total_sales")]
        public int AmountOfSales { get; set; }

        /// <summary>
        /// If the product is virtual. Virtual products are intangible and aren’t shipped. Default is false
        /// </summary>
        [JsonProperty("virtual")]
        public bool Virtual { get; set; }

        /// <summary>
        /// If the product is downloadable. Downloadable products give access to a file upon purchase. Default is false
        /// </summary>
        [JsonProperty("downloadable")]
        public bool Downloadable { get; set; }

        /// <summary>
        /// List of downloadable files.
        /// </summary>
        [JsonProperty("downloads")]
        public DownloadableFile[] Downloads { get; set; }

        /// <summary>
        /// Amount of times the product can be downloaded, the -1 values means unlimited re-downloads. Default is -1
        /// </summary>
        [JsonProperty("download_limit")]
        public int DownloadLimit { get; set; }

        /// <summary>
        /// Number of days that the customer has up to be able to download the product, the -1 means that downloads never expires. Default is -1
        /// </summary>
        [JsonProperty("download_expiry")]
        public int? DownloadExpiry { get; set; }

        /// <summary>
        /// Download type, this controls the schema on the front-end. Default is standard. Options: 'standard' (Standard Product), application (Application/Software) and music (Music)
        /// </summary>
        [JsonProperty("download_type")]
        public string DownloadType
        {
            get
            {
                return this.downloadtype;
            }
            set
            {
                switch (value)
                {
                    case "standard":
                        this.downloadtype = value;
                        return;

                    case "application":
                        this.downloadtype = value;
                        return;

                    case "music":
                        this.downloadtype = value;
                        return;

                    default:
                        throw new ArgumentException("Invalid value. Choices are 'standard', 'application', 'music'");
                }
            }
        }

        /// <summary>
        /// Product external URL. Only for external products
        /// </summary>
        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; }

        /// <summary>
        /// Product external button text. Only for external products
        /// </summary>
        [JsonProperty("button_text")]
        public string ButtonText { get; set; }

        /// <summary>
        /// Tax status. Default is taxable. Options: taxable, shipping (Shipping only) and none
        /// </summary>
        [JsonProperty("tax_status")]
        public string TaxStatus
        {
            get
            {
                return this.taxstatus;
            }
            set
            {
                switch (value)
                {
                    case "taxable":
                        this.taxstatus = value;
                        return;

                    case "shipping":
                        this.taxstatus = value;
                        return;

                    case "none":
                        this.taxstatus = value;
                        return;

                    default:
                        throw new ArgumentException(
                            "Invalid tax status. Choices are 'taxable', 'shipping', 'none'");
                }

            }
        }

        /// <summary>
        /// Tax class
        /// </summary>
        [JsonProperty("tax_class")]
        public string TaxClass { get; set; }

        /// <summary>
        /// Stock management at product level. Default is false
        /// </summary>
        [JsonProperty("manage_stock")]
        public bool ManageStock { get; set; }

        /// <summary>
        /// Stock quantity. If is a variable product this value will be used to control stock for all variations, unless you define stock at variation level
        /// </summary>
        [JsonProperty("stock_quantity")]
        public int? StockQuantity { get; set; }

        /// <summary>
        /// Controls whether or not the product is listed as “in stock” or “out of stock” on the frontend. Default is true
        /// </summary>
        [JsonProperty("in_stock")]
        public bool InStock { get; set; }

        /// <summary>
        /// If managing stock, this controls if backorders are allowed. If enabled, stock quantity can go below 0. Default is no. Options are: no (Do not allow), notify (Allow, but notify customer), and yes (Allow)
        /// </summary>
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
        /// Shows if a product is on backorder (if the product have the stock_quantity negative) [read-only]
        /// </summary>
        [JsonProperty("backordered")]
        public bool BackOrdered { get; set; }

        /// <summary>
        /// Allow one item to be bought in a single order. Default is false [read-only]
        /// </summary>
        [JsonProperty("sold_individually")]
        public bool SoldIndividually { get; set; }

        /// <summary>
        /// Product weight in decimal format
        /// </summary>
        [JsonProperty("weight")]
        public string Weight { get; set; }

        /// <summary>
        /// Product dimensions
        /// </summary>
        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }

        /// <summary>
        /// Shows if the product need to be shipped [read-only]
        /// </summary>
        [JsonProperty("shipping_required")]
        public bool ShippingRequired { get; set; }

        /// <summary>
        /// Shows whether or not the product shipping is taxable [read-only]
        /// </summary>
        [JsonProperty("shipping_taxable")]
        public bool ShippingTaxable { get; set; }

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
        /// Allow reviews. Default is true
        /// </summary>
        [JsonProperty("reviews_allowed")]
        public bool ReviewsAllowed { get; set; }

        /// <summary>
        /// Reviews average rating [read-only]
        /// </summary>
        [JsonProperty("average_rating")]
        public string AverageRating { get; set; }

        /// <summary>
        /// Amount of reviews that the product have [read-only]
        /// </summary>
        [JsonProperty("rating_count")]
        public int RatingCount { get; set; }

        /// <summary>
        /// List of related products IDs (integer) [read-only]
        /// </summary>
        [JsonProperty("related_ids")]
        public int[] RelatedIds { get; set; }

        /// <summary>
        /// List of up-sell products IDs (integer). Up-sells are products which you recommend instead of the currently viewed product, for example, products that are more profitable or better quality or more expensive
        /// </summary>
        [JsonProperty("upsell_ids")]
        public int[] UpsellIds { get; set; }

        /// <summary>
        /// List of cross-sell products IDs. Cross-sells are products which you promote in the cart, based on the current product
        /// </summary>
        [JsonProperty("cross_sell_ids")]
        public int[] CrossSellIds { get; set; }

        /// <summary>
        /// Product parent ID (post_parent)
        /// </summary>
        [JsonProperty("parent_id")]
        public int ParentId { get; set; }

        /// <summary>
        /// Optional note to send the customer after purchase
        /// </summary>
        [JsonProperty("purchase_note")]
        public string PuchaseNote { get; set; }

        /// <summary>
        /// List of categories
        /// </summary>
        [JsonProperty("categories")]
        public List<ProductCategory> Categories { get; set; }

        /// <summary>
        /// List of tags
        /// </summary>
        [JsonProperty("tags")]
        public List<ProductTag> Tags { get; set; }

        /// <summary>
        /// List of images
        /// </summary>
        [JsonProperty("images")]
        public List<Image> Images { get; set; }

        /// <summary>
        /// List of attributes
        /// </summary>
        [JsonProperty("attributes")]
        public Products.Attribute[] Attributes { get; set; }

        /// <summary>
        /// Defaults variation attributes, used only for variations and pre-selected attributes on the frontend
        /// </summary>
        [JsonProperty("default_attributes")]
        public Products.DefaultAttribute[] DefaultAttributes { get; set; }

        /// <summary>
        /// List of variations
        /// </summary>
        [JsonProperty("variations")]
        public Variation[] Variations { get; set; }

        /// <summary>
        /// List of grouped products ID, only for group type products [read-only]
        /// </summary>
        [JsonProperty("grouped_products")]
        public string[] GroupedProducts { get; set; }

        /// <summary>
        /// Menu order, used to custom sort products
        /// </summary>
        [JsonProperty("menu_order")]
        public int MenuOrder { get; set; }

    }

}