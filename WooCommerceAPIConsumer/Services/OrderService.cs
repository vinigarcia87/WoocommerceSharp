using System.Collections.Generic;

namespace SharpCommerce.Services
{
    using System;
    using SharpCommerce.Data.Orders;
    using SharpCommerce.Web;
    using System.Threading.Tasks;

    public class OrderService : Service
    {
        private const string BaseApiEndpoint = "orders";

        public readonly OrderNotesService Notes;

        public OrderService(WoocommerceApiDriver apiDriver)
            : base(apiDriver)
        {
            Notes   = new OrderNotesService(apiDriver);
        }

        /// <summary>
        /// Create an Order
        /// </summary>
        /// <param name="orderData">Order object to be sent.</param>
        /// <returns></returns>
        public async Task<Order> Create(Order orderData)
        {
            return (await Post(apiEndpoint: BaseApiEndpoint, toSerialize: orderData));
        }

        /// <summary>
        /// View an Order
        /// </summary>
        /// <param name="orderId">The identifier of order</param>
        /// <returns>Order object</returns>
        public async Task<Order> Get(int orderId)
        {
            var endPoint = string.Format("{0}/{1}", BaseApiEndpoint, orderId);
            return (await Get<Order>(endPoint));
        }

        /// <summary>
        /// View List of Orders
        /// </summary>
        /// <param name="parameters">Parameters to filter list of orders</param>
        /// <returns>List of Orders</returns>
        public async Task<IEnumerable<Order>> Get(Dictionary<string, string> parameters = null)
        {
            return (await Get<IEnumerable<Order>>(apiEndpoint: BaseApiEndpoint, parameters: parameters));
        }
        
        /// <summary>
        /// Create or Update Multiple Orders
        /// </summary>
        /// <param name="ordersData">Orders object to be created or udpated</param>
        /// <returns></returns>
        public async Task<IEnumerable<Order>> CreateUpdateMany(IEnumerable<Order> ordersData)
        {
            var endPoint = string.Format("{0}/bulk", BaseApiEndpoint);
            return (await Put(apiEndpoint: endPoint, toSerialize: ordersData));
        }

        /// <summary>
        /// Update an Order
        /// </summary>
        /// <param name="orderId">The identifier of Order</param>
        /// <param name="newData">New data that will be updated</param>
        /// <returns>New Order Object</returns>
        public async Task<Order> Update(int orderId, Order newData)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, orderId);
            return (await Put(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// Delete an Order
        /// </summary>
        /// <param name="id">The identifier of Order</param>
        /// <returns></returns>
        public async Task<string> MoveToTrash(int id)
        {
            return await Delete(id);
        }

        /// <summary>
        /// Delete an Order Permanently
        /// </summary>
        /// <param name="id">The identifier of Order</param>
        /// <returns></returns>
        public async Task<string> DeletePermanently(int id)
        {
            return await Delete(id, force: true);
        }

        /// <summary>
        /// View Orders Count
        /// </summary>
        /// <param name="parameters">Parameter to filter the orders</param>
        /// <returns>Number of order's count</returns>
        public async Task<int> Count(Dictionary<string, string> parameters = null)
        {
            var endPoint = string.Format("{0}/count", BaseApiEndpoint);
            return (await Get<dynamic>(endPoint, parameters)).count; 
        }

        private async Task<string> Delete(int id, bool force = false)
        {
            var apiEndpoint = String.Format("{0}/{1}", BaseApiEndpoint, id);
            var parameters = new Dictionary<string, string> { { "force", force.ToString().ToLower() } };
            return (await Delete<dynamic>(apiEndpoint, parameters)).message;
        }
    }
}
