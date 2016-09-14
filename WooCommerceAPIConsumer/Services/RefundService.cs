using System.Collections.Generic;

namespace SharpCommerce.Services
{
    using System;
    using SharpCommerce.Data.Orders;
    using SharpCommerce.Web;
    using System.Threading.Tasks;
    using Data;

    /**
     * The refunds API allows you to create, view, and delete individual refunds.
     */
    public class RefundService : Service
    {
        public RefundService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }

        /// <summary>
        /// Create a Refund For an Order
        /// </summary>
        /// <param name="orderId">The identifier of Order</param>
        /// <param name="newData">Order Note object to be created</param>
        /// <returns></returns>
        public async Task<Refund> Create(int orderId, Refund newData)
        {
            var endPoint = String.Format("orders/{0}/refunds", orderId);
            return (await Post(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// View an Order Refund
        /// </summary>
        /// <param name="orderId">The identifier of Order</param>
        /// <param name="refundId">The identifier of Refund</param>
        /// <returns></returns>
        public async Task<Refund> Get(int orderId, int refundId, Dictionary<string, string> parameters = null)
        {
            var endPoint = String.Format("orders/{0}/refunds/{1}", orderId, refundId);
            return (await Get<Refund>(endPoint, parameters: parameters));
        }

        /// <summary>
        /// View List Of Refund From An Order
        /// </summary>
        /// <param name="orderId">The identifier of Order</param>
        /// <returns></returns>
        public async Task<IEnumerable<Refund>> Get(int orderId, Dictionary<string, string> parameters = null, RequestHeaderParams headerParams = null)
        {
            var endPoint = String.Format("orders/{0}/refunds", orderId);
            return (await Get<IEnumerable<Refund>>(endPoint, parameters: parameters, headerParams: headerParams));
        }

        /// <summary>
        /// Delete a Refund Permanently
        /// </summary>
        /// <param name="orderId">The identifier of Order</param>
        /// <param name="refundId">The identifier of Refund</param>
        /// <returns></returns>
        public async Task<string> DeletePermanently(int orderId, int refundId)
        {
            return await Delete(orderId, refundId, force: true);
        }

        private async Task<string> Delete(int orderId, int refundId, bool force = false)
        {
            var endPoint = String.Format("orders/{0}/refunds/{1}", orderId, refundId);
            var parameters = new Dictionary<string, string> { { "force", force.ToString().ToLower() } };
            return (await Delete<dynamic>(endPoint, parameters)).message;
        }

    }
}
