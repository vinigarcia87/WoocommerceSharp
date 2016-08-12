using System.Collections.Generic;

namespace SharpCommerce.Services
{
    using System;
    using SharpCommerce.Data.Orders;
    using SharpCommerce.Web;
    using System.Threading.Tasks;

    /**
     * The order notes API allows you to create, view, and delete individual order notes.
     * Order notes are added by administrators and programmatically to store data about an order, or order events.
     */
    public class OrderNotesService : Service
    {
        public OrderNotesService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }

        /// <summary>
        /// Create a Note For an Order
        /// </summary>
        /// <param name="orderId">The identifier of Order</param>
        /// <param name="newData">Order Note object to be created</param>
        /// <returns></returns>
        public async Task<OrderNote> Create(int orderId, OrderNote newData)
        {
            var endPoint = String.Format("orders/{0}/notes", orderId);
            return (await Post(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// View an Order Note
        /// </summary>
        /// <param name="orderId">The identifier of Order</param>
        /// <param name="noteId">The identifier of Note</param>
        /// <returns></returns>
        public async Task<OrderNote> Get(int orderId, int noteId)
        {
            var endPoint = String.Format("orders/{0}/notes/{1}", orderId, noteId);
            return (await Get<OrderNote>(endPoint));
        }

        /// <summary>
        /// View List Of Notes From An Order
        /// </summary>
        /// <param name="orderId">The identifier of Order</param>
        /// <returns></returns>
        public async Task<IEnumerable<OrderNote>> Get(int orderId)
        {
            var endPoint = String.Format("orders/{0}/notes", orderId);
            return (await Get<IEnumerable<OrderNote>>(endPoint));
        }

        /// <summary>
        /// Delete An Order Note
        /// </summary>
        /// <param name="orderId">The identifier of Order</param>
        /// <param name="noteId">The identifier of Note</param>
        /// <returns></returns>
        public async Task<string> Delete(int orderId, int noteId)
        {
            var endpoint = String.Format("orders/{0}/notes/{1}", orderId, noteId);
            return (await Delete<dynamic>(endpoint)).message;
        }
    }
}
