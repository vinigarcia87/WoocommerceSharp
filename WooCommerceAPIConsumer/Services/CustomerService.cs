using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharpCommerce.Services
{
    using SharpCommerce.Data.Customers;
    using SharpCommerce.Data.Downloads;
    using SharpCommerce.Data.Orders;
    using SharpCommerce.Web;

    /**
     * The customer API allows you to create, view, update, and delete individual, or a batch, of customers.
     */
    public class CustomerService : Service
    {
        private const string BaseApiEndpoint = "customers";

        public CustomerService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }

        /// <summary>
        /// Create a Customer
        /// </summary>
        /// <param name="orderData"></param>
        /// <returns></returns>
        public async Task<Customer> Create(Customer orderData)
        {
            return (await Post(apiEndpoint: BaseApiEndpoint, toSerialize: orderData));
        }

        /// <summary>
        /// View a Customer by ID
        /// </summary>
        /// <param name="customerId">The identifier of customer</param>
        /// <returns></returns>
        public async Task<Customer> Get(int customerId)
        {
            var endPoint = string.Format("{0}/{1}", BaseApiEndpoint, customerId);
            return (await Get<Customer>(endPoint));
        }

        /// <summary>
        /// View List of Customers
        /// </summary>
        /// <param name="parameters">Parameters to filter list of customers</param>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> Get(Dictionary<string, string> parameters = null)
        {
            return (await Get<IEnumerable<Customer>>(apiEndpoint: BaseApiEndpoint, parameters: parameters));
        }

        /// <summary>
        /// Update a Customer
        /// </summary>
        /// <param name="customerId">The identifier of customer</param>
        /// <param name="newData">Customer object to be updated</param>
        /// <returns></returns>
        public async Task<Customer> Update(int customerId, Customer newData)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, customerId);
            return (await Put(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// Create or Update Multiple Customers
        /// </summary>
        /// <param name="ordersData">List of customer object to be created or updated</param>
        /// <returns></returns>
        public async Task<IEnumerable<Customer>> CreateUpdateMany(IEnumerable<Customer> ordersData)
        {
            var endPoint = String.Format("{0}/bulk", BaseApiEndpoint);
            return (await Put(apiEndpoint: endPoint, toSerialize: ordersData));
        }

        /// <summary>
        /// Delete a Customer Permanently
        /// </summary>
        /// <param name="id">The identifier of Customer</param>
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
        /// View Customers Count. 
        /// Can have the 'role' filter for customers vs subscribers
        /// </summary>
        /// <param name="parameters">Parameter to filter list of customer </param>
        /// <returns></returns>
        public async Task<int> Count(Dictionary<string, string> parameters = null)
        {
            var endPoint = string.Format("{0}/count", BaseApiEndpoint);
            return (await Get<dynamic>(apiEndpoint: endPoint, parameters: parameters)).count;
        }

        /// <summary>
        /// View Customer's Download
        /// </summary>
        /// <param name="customerId">The identifier of customer</param>
        /// <param name="parameters">Parameter to filter list of downloads</param>
        /// <returns></returns>
        public async Task<IEnumerable<Download>> GetDownloads(int customerId, Dictionary<string, string> parameters = null)
        {
            var endPoint = String.Format("{0}/{1}/downloads", BaseApiEndpoint, customerId);
            return (await Get<IEnumerable<Download>>(endPoint, parameters: parameters));
        }
    }
}
