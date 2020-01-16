using ShoppingBasket.Model;
using ShoppingBasket.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Service.Common
{
    /// <summary>
    /// Basket service contract.
    /// </summary>
    public interface IBasketService
    {
        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task<bool> CreateAsync(IBasket model);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task<bool> UpdateAsync(Guid id, IBasket model);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<bool> DeleteAsync(Guid id);

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<IBasket> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the total asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<decimal> GetTotalAsync(Guid id);

        /// <summary>
        /// Adds the product to basket asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public Task<IBasket> AddProductToBasketAsync(Guid userId, Guid productId, int quantity);

        /// <summary>
        /// Gets the user basket asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public Task<IBasket> GetUserBasketAsync(Guid userId);

        /// <summary>
        /// Applies the discounts asynchronous.
        /// </summary>
        /// <param name="basket">The basket.</param>
        /// <returns></returns>
        public Task<IBasket> ApplyDiscountsAsync(IBasket basket);
    }
}
