using System;
using System.Collections.Generic;

namespace SharpCommerce.Services
{
    using SharpCommerce.Data.Products;
    using SharpCommerce.Web;
    using System.Threading.Tasks;

    /**
     * The products API allows you to create, view, update, and delete individual, or a batch, of products.
     */
    public class ProductService : Service
    {
        private const string BaseApiEndpoint = "products";

        public ProductService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }

        /// <summary>
        /// Create a product
        /// </summary>
        /// <param name="productData">Product object to be created</param>
        /// <returns>Created product object</returns>
        public async Task<Product> Create(Product productData)
        {
            var endPoint = String.Format("{0}", BaseApiEndpoint);
            return (await Post(apiEndpoint: endPoint, toSerialize: productData));
        }


        /// <summary>
        /// View a Product
        /// </summary>
        /// <param name="productId">The identifier of product</param>
        /// <returns>A product object</returns>
        public async Task<Product> Get(int productId)
        {
            var endPoint = string.Format("{0}/{1}", BaseApiEndpoint, productId);
            return (await Get<Product>(endPoint));
        }

        /// <summary>
        /// View List of Products
        /// </summary>
        /// <param name="parameters">Parameters to filter list of products</param>
        /// <returns>List of Products Object</returns>
        public async Task<IEnumerable<Product>> Get(Dictionary<string, string> parameters = null)
        {
            var endPoint = String.Format("{0}", BaseApiEndpoint);
            return (await Get<IEnumerable<Product>>(endPoint, parameters));
        }

        /// <summary>
        /// Updated a Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="newData"></param>
        /// <returns></returns>
        public async Task<Product> Update(int productId, Product newData)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, productId);
            return (await Put(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// Create or Update Multiple Products
        /// </summary>
        /// <param name="productsData">List of product object to be updated.</param>
        /// <returns>List of updated product object</returns>
        public async Task<IEnumerable<Product>> CreateUpdateMany(IEnumerable<Product> productsData)
        {
            var endPoint = String.Format("{0}/batch", BaseApiEndpoint);
            return (await Put(endPoint, toSerialize: productsData));
        }

        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <param name="id">The identifier or product</param>
        /// <returns></returns>
        public async Task<string> MoveToTrash(int id)
        {
            return await Delete(id);
        }

        /// <summary>
        /// Delete a Product Permanently.
        /// </summary>
        /// <param name="id">The identifier of product</param>
        /// <returns></returns>
        public async Task<string> DeletePermanently(int id)
        {
            return await Delete(id, force: true);
        }

        private async Task<string> Delete(int id, bool force = false)
        {
            var apiEndpoint = String.Format("{0}/{1}", BaseApiEndpoint, id);
            var parameters = new Dictionary<string, string> { { "force", force.ToString().ToLower() } };
            return (await Delete<dynamic>(apiEndpoint, parameters)).message;
        }

        /// <summary>
        /// View a Product Review
        /// </summary>
        /// <param name="productId">The identifier of product</param>
        /// <returns>A product review object</returns>
        public async Task<ProductReview> GetProductReview(int productId, int reviewId)
        {
            var endPoint = string.Format("{0}/{1}/reviews/{2}", BaseApiEndpoint, productId, reviewId);
            return (await Get<ProductReview>(endPoint));
        }

        /// <summary>
        /// View all Product Reviews
        /// </summary>
        /// <returns>List of product review object</returns>
        public async Task<IEnumerable<ProductReview>> GetProductReviews(int productId)
        {
            var endPoint = string.Format("{0}/{1}/reviews", BaseApiEndpoint, productId);
            return (await Get<IEnumerable<ProductReview>>(endPoint));
        }

        /// <summary>
        /// View Products Count 
        /// </summary>
        /// <param name="parameters">parameter filter constraint</param>
        /// <returns></returns>
        public async Task<int> Count(Dictionary<string, string> parameters = null)
        {
            var endPoint = String.Format("{0}/count", BaseApiEndpoint);
            return (await Get<dynamic>(endPoint, parameters)).count;
        }
    }
}
