using ShoppingBasket.DAL.Entities;
using ShoppingBasket.Model.Common;
using System;
using System.Threading.Tasks;

namespace ShoppingBasket.Repository.Common
{
    /// <summary>
    /// Basket repository contract.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.Common.IBaseRepository{ShoppingBasket.DAL.Entities.Basket}" />
    public interface IBasketRepository : IBaseRepository<Basket>
    {
        /// <summary>
        /// Adds the product to basket.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public Task<IBasket> AddProductToBasket(Guid userId, Guid productId, int quantity);

        /// <summary>
        /// Deletes the product from basket.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public Task<IBasket> DeleteProductFromBasket(Guid userId, Guid productId, int quantity);

        /// <summary>
        /// Gets the user basket asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public Task<IBasket> GetUserBasketAsync(Guid userId);
    }
}
