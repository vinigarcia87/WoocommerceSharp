using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpCommerce.Services
{
    using SharpCommerce.Data.Products;
    using SharpCommerce.Web;

    public class ProductTagService : Service
    {
        private const string BaseApiEndpoint = "products/tags";

        public ProductTagService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }

        /// <summary>
        /// View a Product Tags
        /// </summary>
        /// <returns>a product tags</returns>
        public async Task<ProductTag> Get(int productTagId)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, productTagId);
            return (await Get<ProductTag>(endPoint));
        }

        /// <summary>
        /// View a List of Product Tags
        /// </summary>
        /// <param name="parameters">Parameters to filter list of product tags</param>
        /// <returns>List of product tags</returns>
        public async Task<IEnumerable<ProductTag>> Get(Dictionary<string, string> parameters = null)
        {
            return (await Get<IEnumerable<ProductTag>>(BaseApiEndpoint, parameters));
        }


    }
}
