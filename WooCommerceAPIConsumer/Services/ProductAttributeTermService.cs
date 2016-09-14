using System;
using System.Collections.Generic;

namespace SharpCommerce.Services
{
    using Data;
    using SharpCommerce.Data.Products;
    using SharpCommerce.Web;
    using System.Threading.Tasks;

    /**
     * The product attribute terms API allows you to create, view, update, and delete individual, or a batch, of attribute terms.
     */
    public class ProductAttributeTermService : Service
    {
        private const string BaseApiEndpoint = "products/attributes";

        public ProductAttributeTermService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }

        /// <summary>
        /// Create a Product Attribute Term
        /// </summary>
        /// <param name="productAttributeId">The identifiter of product attribute</param>
        /// <param name="productAttributeTermData">Product attribute term to be created</param>
        /// <returns>Newly created product attribute term object</returns>
        public async Task<ProductAttributeTerm> Create(int productAttributeId, ProductAttributeTerm productAttributeTermData)
        {
            var endPoint = String.Format("{0}/{1}/terms", BaseApiEndpoint, productAttributeId);
            return (await Post(apiEndpoint: endPoint, toSerialize: productAttributeTermData));
        }

        /// <summary>
        /// View a Product Attribute Term
        /// </summary>
        /// <param name="productAttributeId">The identifiter of product attribute</param>
        /// <param name="productAttributeTermId">The identifiter of product attribute term</param>
        /// <returns>A product attribute term object</returns>
        public async Task<ProductAttributeTerm> Get(int productAttributeId, int productAttributeTermId)
        {
            var endPoint = String.Format("{0}/{1}/terms/{2}", BaseApiEndpoint, productAttributeId, productAttributeTermId);
            return (await Get<ProductAttributeTerm>(endPoint));
        }

        /// <summary>
        /// View List of Product Attribute Terms
        /// </summary>
        /// <param name="productAttributeId">The identifiter of product attribute</param>
        /// <param name="parameters">Parameter to filter list of product attribute terms</param>
        /// <returns>List of product attribute terms object</returns>
        public async Task<IEnumerable<ProductAttributeTerm>> Get(int productAttributeId, Dictionary<string, string> parameters = null, RequestHeaderParams headerParams = null)
        {
            var endPoint = String.Format("{0}/{1}/terms", BaseApiEndpoint, productAttributeId);
            return (await Get<IEnumerable<ProductAttributeTerm>>(apiEndpoint: endPoint, parameters: parameters, headerParams: headerParams));
        }

        /// <summary>
        /// Update a product attribute term
        /// </summary>
        /// <param name="productAttributeId">The identifier of product attribute</param>
        /// <param name="productAttributeTermId">The identifiter of product attribute term</param>
        /// <param name="newData">The new data to be updated</param>
        /// <returns>New product attribute term object</returns>
        public async Task<ProductAttributeTerm> Update(int productAttributeId, int productAttributeTermId, ProductAttributeTerm newData)
        {
            var endPoint = String.Format("{0}/{1}/terms/{2}", BaseApiEndpoint, productAttributeId, productAttributeTermId);
            return (await Put(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// Create or Update Multiple Product Attributes
        /// </summary>
        /// <param name="productAttributeId">The identifier of product attribute</param>
        /// <param name="productAttributeTermData">List of Product Attribute Terms object to be created or udpated</param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductAttributeTerm>> CreateUpdateMany(int productAttributeId, IEnumerable<ProductAttributeTerm> productAttributeTermData)
        {
            var endPoint = string.Format("{0}/{1}/terms/batch", BaseApiEndpoint, productAttributeId);
            return (await Put(apiEndpoint: endPoint, toSerialize: productAttributeTermData));
        }

        /// <summary>
        /// Delete a Product Attribute Permanently
        /// Note: This also will delete all terms from the selected attribute
        /// </summary>
        /// <param name="id">The identifier of product attribute</param>
        /// <returns></returns>
        public async Task<string> DeletePermanently(int productAttributeId, int productAttributeTermId)
        {
            return await Delete(productAttributeId, productAttributeTermId, force: true);
        }

        private async Task<string> Delete(int productAttributeId, int productAttributeTermId, bool force = false)
        {
            var endPoint = String.Format("{0}/{1}/terms/{2}", BaseApiEndpoint, productAttributeId, productAttributeTermId);
            var parameters = new Dictionary<string, string> { { "force", force.ToString().ToLower() } };
            return(await  Delete<dynamic>(endPoint, parameters)).message;
        }
    }
}
