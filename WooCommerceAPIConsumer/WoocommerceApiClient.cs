namespace SharpCommerce
{
    using SharpCommerce.Services;
    using SharpCommerce.Web;

    public class WoocommerceApiClient
    {
        #region WooCommerce API
        public readonly CouponService Coupons;
        public readonly CustomerService Customers;
        public readonly OrderService Orders;
        public readonly OrderNotesService OrderNotes;
        public readonly RefundService Refunds;
        public readonly ProductService Products;
        public readonly ProductAttributeService ProductAttributes;
        public readonly ProductAttributeTermService ProductAttributeTerms;
        public readonly ProductCategoryService ProductCategories;
        public readonly ProductTagService ProductTags;
        public readonly ProductShippingClassService ProductShippingClasses;

        // @TODO Implement the following classes
        //public readonly ReportService Reports;
        //public readonly TaxRateService TaxRates;
        //public readonly TaxClassService TaxClasses;
        #endregion

        public WoocommerceApiClient(string storeUrl, string consumerKey, string consumerSecret, bool isSsl = false, bool queryStringAuth = false)
        {
            #region WooCommerce API Services
            var apiWooDriver = new WoocommerceApiDriver(storeUrl, consumerKey, consumerSecret, "wp-json/wc/v1/", isSsl, queryStringAuth);

            // this.WooIndex = new IndexService(apiWooDriver);
            this.Coupons = new CouponService(apiWooDriver);
            this.Customers = new CustomerService(apiWooDriver);
            this.Orders = new OrderService(apiWooDriver);
            this.OrderNotes = new OrderNotesService(apiWooDriver);
            this.Refunds = new RefundService(apiWooDriver);
            this.Products = new ProductService(apiWooDriver);
            this.ProductAttributes = new ProductAttributeService(apiWooDriver);
            this.ProductAttributeTerms = new ProductAttributeTermService(apiWooDriver);
            this.ProductCategories = new ProductCategoryService(apiWooDriver);
            this.ProductTags = new ProductTagService(apiWooDriver);
            this.ProductShippingClasses = new ProductShippingClassService(apiWooDriver);

            // @TODO Implement the following classes
            //this.Reports = new ReportService(apiWooDriver);
            //this.TaxRates = new TaxRateService(apiWooDriver);
            //this.TaxClasses = new TaxClassService(apiWooDriver);
            #endregion

            #region MyCustom API Services
            // You can create easily a client for your custom routes on Wordpress
            //var apiDexDriver = new WoocommerceApiDriver(storeUrl, consumerKey, consumerSecret, "wp-json/wc-mycustomapi/v1/", isSsl, queryStringAuth);

            // this.MyCustomIndex = new IndexService(apiDexDriver);
            // ...
            #endregion
        }
    }
}
