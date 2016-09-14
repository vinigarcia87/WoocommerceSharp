using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpCommerce.Services
{
    using Data;
    using SharpCommerce.Data.Products;
    using SharpCommerce.Web;

    /**
     * The product categories API allows you to create, view, update, and delete individual, or a batch, of categories.
     */
    public class ProductCategoryService : Service
    {
        private const string BaseApiEndpoint = "products/categories";

        public ProductCategoryService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }


        /// <summary>
        /// Create a product category
        /// </summary>
        /// <param name="productCategoryData">Product object to be created</param>
        /// <returns>Created product category object</returns>
        public async Task<ProductCategory> Create(ProductCategory productCategoryData)
        {
            var endPoint = String.Format("{0}", BaseApiEndpoint);
            return (await Post(apiEndpoint: endPoint, toSerialize: productCategoryData));
        }


        /// <summary>
        /// View a product category
        /// </summary>
        /// <param name="productCategoryId">The identifier of product category</param>
        /// <returns>A product object</returns>
        public async Task<ProductCategory> Get(int productCategoryId)
        {
            var endPoint = string.Format("{0}/{1}", BaseApiEndpoint, productCategoryId);
            return (await Get<ProductCategory>(endPoint));
        }

        /// <summary>
        /// View List of product categories
        /// </summary>
        /// <param name="parameters">Parameters to filter list of product categories</param>
        /// <returns>List of Products Object</returns>
        public async Task<IEnumerable<ProductCategory>> Get(Dictionary<string, string> parameters = null, RequestHeaderParams headerParams = null)
        {
            var endPoint = String.Format("{0}", BaseApiEndpoint);
            return (await Get<IEnumerable<ProductCategory>>(endPoint, parameters, headerParams: headerParams));
        }

        /// <summary>
        /// Update a product category
        /// </summary>
        /// <param name="productCategoryId">The identifier of product category</param>
        /// <param name="newData">Product category object to be updated</param>
        /// <returns></returns>
        public async Task<ProductCategory> Update(int productCategoryId, ProductCategory newData)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, productCategoryId);
            return (await Put(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// Create or Update Multiple product categories
        /// </summary>
        /// <param name="productCategoriesData">List of product categories object to be updated</param>
        /// <returns>List of updated product category object</returns>
        public async Task<IEnumerable<ProductCategory>> CreateUpdateMany(IEnumerable<ProductCategory> productCategoriesData)
        {
            var endPoint = String.Format("{0}/batch", BaseApiEndpoint);
            return (await Put(endPoint, toSerialize: productCategoriesData));
        }

        /// <summary>
        /// Delete a product category Permanently.
        /// </summary>
        /// <param name="id">The identifier of product category</param>
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

    }
}
