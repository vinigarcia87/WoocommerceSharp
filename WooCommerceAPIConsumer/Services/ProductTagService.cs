using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpCommerce.Services
{
    using SharpCommerce.Data.Products;
    using SharpCommerce.Web;

    /**
     * The product tags API allows you to create, view, update, and delete individual, or a batch, of product tags.
     */
    public class ProductTagService : Service
    {
        private const string BaseApiEndpoint = "products/tags";

        public ProductTagService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }

        /// <summary>
        /// Create a product tag
        /// </summary>
        /// <param name="productTagData">Product tag object to be created</param>
        /// <returns>Created product tag object</returns>
        public async Task<ProductTag> Create(ProductTag productTagData)
        {
            var endPoint = String.Format("{0}", BaseApiEndpoint);
            return (await Post(apiEndpoint: endPoint, toSerialize: productTagData));
        }


        /// <summary>
        /// View a product tag
        /// </summary>
        /// <param name="productTagId">The identifier of product tag</param>
        /// <returns>A product tag object</returns>
        public async Task<ProductTag> Get(int productTagId)
        {
            var endPoint = string.Format("{0}/{1}", BaseApiEndpoint, productTagId);
            return (await Get<ProductTag>(endPoint));
        }

        /// <summary>
        /// View List of product tags
        /// </summary>
        /// <param name="parameters">Parameters to filter list of product tags</param>
        /// <returns>List of Products Object</returns>
        public async Task<IEnumerable<ProductTag>> Get(Dictionary<string, string> parameters = null)
        {
            var endPoint = String.Format("{0}", BaseApiEndpoint);
            return (await Get<IEnumerable<ProductTag>>(endPoint, parameters));
        }

        /// <summary>
        /// Update a product tag
        /// </summary>
        /// <param name="productTagId">The identifier of product tag</param>
        /// <param name="newData">Product tag object to be updated</param>
        /// <returns></returns>
        public async Task<ProductTag> Update(int productTagId, ProductTag newData)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, productTagId);
            return (await Put(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// Create or Update Multiple product tags
        /// </summary>
        /// <param name="productTagsData">List of product tags object to be updated</param>
        /// <returns>List of updated product tags object</returns>
        public async Task<IEnumerable<ProductTag>> CreateUpdateMany(IEnumerable<ProductTag> productTagsData)
        {
            var endPoint = String.Format("{0}/batch", BaseApiEndpoint);
            return (await Put(endPoint, toSerialize: productTagsData));
        }

        /// <summary>
        /// Delete a product tag Permanently.
        /// </summary>
        /// <param name="id">The identifier of product tag</param>
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
