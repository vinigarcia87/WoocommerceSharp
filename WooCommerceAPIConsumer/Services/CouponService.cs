namespace SharpCommerce.Services
{
    using System;
    using System.Collections.Generic;

    using SharpCommerce.Data.Coupons;
    using SharpCommerce.Web;
    using System.Threading.Tasks;
    using Data;

    /**
     * The coupons API allows you to create, view, update, and delete individual, or a batch, of coupon codes.
     */
    public class CouponService : Service
    {
        private const string BaseApiEndpoint = "coupons";

        public CouponService(WoocommerceApiDriver apiDriver)
            : base(apiDriver) { }

        /// <summary>
        /// Create a Coupon
        /// </summary>
        /// <param name="orderData"></param>
        /// <returns></returns>
        public async Task<Coupon> Create(Coupon orderData)
        {
            return (await Post(apiEndpoint: BaseApiEndpoint, toSerialize: orderData));
        }

        /// <summary>
        /// View a Coupon by ID
        /// </summary>
        /// <param name="couponId">The identifier of Coupon</param>
        /// <returns>Specified coupon object</returns>
        public async Task<Coupon> Get(int couponId)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, couponId);
            return (await Get<Coupon>(endPoint));
        }

        /// <summary>
        /// List of Coupons
        /// </summary>
        /// <param name="parameters">Parameter to filter list of coupon</param>
        /// <returns>List of Coupon objects</returns>
        public async Task<IEnumerable<Coupon>> Get(Dictionary<string, string> parameters = null, RequestHeaderParams headerParams = null)
        {
            return (await Get<IEnumerable<Coupon>>(BaseApiEndpoint, parameters, headerParams: headerParams));
        }

        /// <summary>
        /// Update a Coupon
        /// </summary>
        /// <param name="couponId">The identifier of Coupon</param>
        /// <param name="newData">Coupon object to be updated</param>
        /// <returns>The new updated coupon</returns>
        public async Task<Coupon> Update(int couponId, Coupon newData)
        {
            var endPoint = String.Format("{0}/{1}", BaseApiEndpoint, couponId);
            return (await Put(endPoint, toSerialize: newData));
        }

        /// <summary>
        /// Create or Update Multiple Coupon
        /// </summary>
        /// <param name="ordersData">Multiple coupon object to be created or updated</param>
        /// <returns></returns>
        public async Task<IEnumerable<Coupon>> CreateUpdateMany(IEnumerable<Coupon> ordersData)
        {
            var endPoint = String.Format("{0}/batch", BaseApiEndpoint);
            return (await Put(endPoint, toSerialize: ordersData));
        }

        /// <summary>
        /// Delete a Coupon
        /// </summary>
        /// <param name="id">The identifier of coupon to be deleted</param>
        /// <returns></returns>
        public async Task<string> MoveToTrash(int id)
        {
            return await Delete(id);
        }

        /// <summary>
        /// Delete a Coupon Permanently
        /// </summary>
        /// <param name="id">The identifier of coupon to be deleted</param>
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
        /// View Coupon Count
        /// </summary>
        /// <param name="parameters">Parameter to filter list of Coupons</param>
        /// <returns>Number of coupon count</returns>
        public async Task<int> Count(Dictionary<string, string> parameters = null)
        {
            var endPoint = String.Format("{0}/count", BaseApiEndpoint);
            return (await Get<dynamic>(apiEndpoint: endPoint, parameters: parameters)).count;
        }
    }
}





