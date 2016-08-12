using System;
using System.Collections.Generic;

namespace SharpCommerce.Services
{
    using SharpCommerce.Data.Products;
    using SharpCommerce.Web;
    using System.Threading.Tasks;

    /**
     * The product attributes API allows you to create, view, update, and delete individual, or a batch, of product attributes.
     */
    public class ProductAttributeService : Service
    {
        private const string BaseApiEndpoint = "products/attributes";

        public ProductAttributeService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }

        /// <summary>
        /// Create a Product Attribute 
        /// </summary>
        /// <param name="productAttributeData">Product attribute to be created</param>
        /// <returns>Newly created product attribute object</returns>
        public async Task<ProductAttribute> Create(ProductAttribute productAttributeData)
        {
            return (await Post(apiEndpoint: BaseApiEndpoint, toSerialize: productAttributeData));
        }

        /// <summary>
        /// View a Product Attribute
        /// </summary>
        /// <param name="productAttributeId">The identifiter of product attribute</param>
        /// <returns>A product attribute object</returns>
        public async Task<ProductAttribute> Get(int productAttributeId)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, productAttributeId);
            return (await Get<ProductAttribute>(endPoint));
        }

        /// <summary>
        /// View List of Product Attributes
        /// </summary>
        /// <param name="parameters">Parameter to filter list of product attributes</param>
        /// <returns>List of product attributes object</returns>
        public async Task<IEnumerable<ProductAttribute>> Get(Dictionary<string, string> parameters = null)
        {
            return (await Get<IEnumerable<ProductAttribute>>(apiEndpoint: BaseApiEndpoint, parameters: parameters));
        }

        /// <summary>
        /// Update a product attribute
        /// </summary>
        /// <param name="productAttributeId">The identifier of product attribute</param>
        /// <param name="newData">The new data to be updated</param>
        /// <returns>New product attribute object</returns>
        public async Task<ProductAttribute> Update(int productAttributeId, ProductAttribute newData)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, productAttributeId);
            return (await Put(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// Create or Update Multiple Product Attributes
        /// </summary>
        /// <param name="productAttributeData">List of Product Attributes object to be created or udpated</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttribute>> CreateUpdateMany(IEnumerable<ProductAttribute> productAttributeData)
        {
            var endPoint = string.Format("{0}/batch", BaseApiEndpoint);
            return (await Put(apiEndpoint: endPoint, toSerialize: productAttributeData));
        }

        /// <summary>
        /// Delete a Product Attribute Permanently
        /// Note: This also will delete all terms from the selected attribute
        /// </summary>
        /// <param name="id">The identifier of product attribute</param>
        /// <returns></returns>
        public async Task<string> DeletePermanently(int id)
        {
            return await Delete(id, force: true);
        }

        private async Task<string> Delete(int id, bool force = false)
        {
            var apiEndpoint = String.Format("{0}/{1}", BaseApiEndpoint, id);
            var parameters = new Dictionary<string, string> { { "force", force.ToString().ToLower() } };
            return(await  Delete<dynamic>(apiEndpoint, parameters)).message;
        }
    }
}
