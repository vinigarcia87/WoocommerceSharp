namespace SharpCommerce
{
    using SharpCommerce.Services;
    using SharpCommerce.Web;

    public class WoocommerceApiClient
    {
        #region WooCommerce API
        readonly OrderService Orders;
        public readonly CouponService Coupons;
        public readonly CustomerService Customers;
        public readonly ProductService Products;
        #endregion

        public WoocommerceApiClient(string storeUrl, string consumerKey, string consumerSecret)
        {
            var apiWooDriver = new WoocommerceApiDriver(storeUrl, consumerKey, consumerSecret, "wp-json/wc/v1/");

            // this.Index = new IndexService(apiWooDriver);
            this.Coupons = new CouponService(apiWooDriver);
            this.Customers = new CustomerService(apiWooDriver);
            this.Orders = new OrderService(apiWooDriver);
            this.Products = new ProductService(apiWooDriver);
            // this.Reports = new ReportsService(apiWooDriver);

            var apiDexDriver = new WoocommerceApiDriver(storeUrl, consumerKey, consumerSecret, "wp-json/wc-mycustomapi/v1/");

            // this.Index = new IndexService(apiDexDriver);
            //this.Concessionarias = new ConcessionariaService(apiDexDriver);
            //this.Produtos = new ProdutoService(apiDexDriver);
        }
    }
}
