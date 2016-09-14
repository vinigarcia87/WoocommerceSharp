using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpCommerce.Services
{
    using Data;
    using SharpCommerce.Data.Products;
    using SharpCommerce.Web;

    /**
     * The product shipping class API allows you to create, view, update, and delete individual, or a batch, of shipping classes.
     */
    public class ProductShippingClassService : Service
    {
        private const string BaseApiEndpoint = "products/shipping_classes";

        public ProductShippingClassService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }

        /// <summary>
        /// Create a shipping class
        /// </summary>
        /// <param name="productShippingClassData">Product shipping class object to be created</param>
        /// <returns>Created product shipping class object</returns>
        public async Task<ProductShippingClass> Create(ProductShippingClass productShippingClassData)
        {
            var endPoint = String.Format("{0}", BaseApiEndpoint);
            return (await Post(apiEndpoint: endPoint, toSerialize: productShippingClassData));
        }


        /// <summary>
        /// View a product shipping class
        /// </summary>
        /// <param name="productShippingClassId">The identifier of product shipping class</param>
        /// <returns>A product shipping class object</returns>
        public async Task<ProductShippingClass> Get(int productShippingClassId)
        {
            var endPoint = string.Format("{0}/{1}", BaseApiEndpoint, productShippingClassId);
            return (await Get<ProductShippingClass>(endPoint));
        }

        /// <summary>
        /// View List of product shipping classes
        /// </summary>
        /// <param name="parameters">Parameters to filter list of product shipping classes</param>
        /// <returns>List of Product shipping classes Object</returns>
        public async Task<IEnumerable<ProductShippingClass>> Get(Dictionary<string, string> parameters = null, RequestHeaderParams headerParams = null)
        {
            var endPoint = String.Format("{0}", BaseApiEndpoint);
            return (await Get<IEnumerable<ProductShippingClass>>(endPoint, parameters, headerParams: headerParams));
        }

        /// <summary>
        /// Update a product shipping class
        /// </summary>
        /// <param name="productShippingClassId">The identifier of product shipping class</param>
        /// <param name="newData">Product shipping class object to be updated</param>
        /// <returns></returns>
        public async Task<ProductShippingClass> Update(int productShippingClassId, ProductShippingClass newData)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, productShippingClassId);
            return (await Put(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// Create or Update Multiple product shipping classes
        /// </summary>
        /// <param name="productShippingClassesData">List of product shipping classes object to be updated</param>
        /// <returns>List of updated product shipping classes object</returns>
        public async Task<IEnumerable<ProductShippingClass>> CreateUpdateMany(IEnumerable<ProductShippingClass> productShippingClassesData)
        {
            var endPoint = String.Format("{0}/batch", BaseApiEndpoint);
            return (await Put(endPoint, toSerialize: productShippingClassesData));
        }

        /// <summary>
        /// Delete a product shipping class Permanently.
        /// </summary>
        /// <param name="id">The identifier of product shipping class</param>
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
