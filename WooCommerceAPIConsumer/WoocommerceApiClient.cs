namespace SharpCommerce
{
    using SharpCommerce.Services;
    using SharpCommerce.Web;

    public class WoocommerceApiClient
    {
        #region WooCommerce API
        public readonly OrderService Orders;
        public readonly CouponService Coupons;
        public readonly CustomerService Customers;
        public readonly ProductService Products;
        #endregion

        #region DexPeças API
        //public readonly ConcessionariasService Concessionarias;
        //public readonly ProdutoService Produtos;
        #endregion

        public WoocommerceApiClient(string storeUrl, string consumerKey, string consumerSecret)
        {
            #region WooCommerce API Services
            var apiWooDriver = new WoocommerceApiDriver(storeUrl, consumerKey, consumerSecret, "wp-json/wc/v1/");

            // this.WooIndex = new IndexService(apiWooDriver);
            this.Coupons = new CouponService(apiWooDriver);
            this.Customers = new CustomerService(apiWooDriver);
            this.Orders = new OrderService(apiWooDriver);
            this.Products = new ProductService(apiWooDriver);
            // @TODO Implement the following classes
            //this.ProductAttributeTerms = new ProductAttributeTermsService(apiWooDriver);
            //this.ProductShippingClasses = new ProductShippingClassesService(apiWooDriver);
            //this.TaxRates = new TaxRatesService(apiWooDriver);
            //this.TaxClasses = new TaxClassesService(apiWooDriver);
            //this.Refunds = new RefundService(apiWooDriver);
            // this.Reports = new ReportsService(apiWooDriver);
            #endregion

            #region MyCustom API Services
            var apiDexDriver = new WoocommerceApiDriver(storeUrl, consumerKey, consumerSecret, "wp-json/wc-mycustom/v1/");

            // @TODO Implement the following classes
            // this.MyCustomIndex = new IndexService(apiDexDriver);
            //this.Concessionarias = new ConcessionariaService(apiDexDriver);
            //this.Produtos = new ProdutoService(apiDexDriver);
            #endregion
        }
    }
}
