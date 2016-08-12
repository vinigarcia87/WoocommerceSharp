using System;

namespace WooCommerceAPIClient
{
    using SharpCommerce;
    using SharpCommerce.Data.Customers;
    using SharpCommerce.Data.Orders;
    using System.Collections.Generic;

    using SharpCommerce.Services;
    using SharpCommerce.Data.Products;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            #region Credentials

            // Wordpress Server
            const string StoreUrl = "https://mywebsite.com/";
            const string ConsumerKey = "ck_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            const string ConsumerSecret = "cs_xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            const bool IsSsl = true;
            const bool QueryStringAuth = false; // Force Basic Authentication as query string true and using under HTTPS

            #endregion

            var api = new WoocommerceApiClient(StoreUrl, ConsumerKey, ConsumerSecret, IsSsl, QueryStringAuth);
            var parameters = new Dictionary<string, string>();

            #region Category

            ProductCategory categoria = new ProductCategory
            {
                Name = "New Category",
                Slug = "new-category",
                Descripton = "Nice description about this new category",
                Display = "default",
                Image = new Image
                {
                    Src = "http://omecanico.com.br/wp-content/uploads/2016/02/626-ALLISON-4000-Series.jpg",
                }
            };

            var catResult = api.ProductCategories.Create(categoria).Result;
            Console.WriteLine("{0} - {1} - {2} - {3}", catResult.Id, catResult.Name, catResult.Slug, catResult.Descripton);

            #endregion

            Console.WriteLine("Press enter to start the next test...");
            Console.ReadLine();

            #region Produtos

            var id = 99;
            var productResult = api.Products.Get(id).Result;
            Console.WriteLine("( {0} ) {1} - {2}", productResult.Id, productResult.Sku, productResult.Name);

            #endregion

            /* *********************************************** */

            Console.WriteLine("Press enter to close...");
            Console.ReadLine();

        }
    }
}
