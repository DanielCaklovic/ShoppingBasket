using ShoppingBasket.DAL.Entities;
using System;
using System.Collections.Generic;
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
        /// <param name="basket">The basket.</param>
        /// <param name="product">The product.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public Task<Basket> AddProductToBasket(Basket basket, Product product, int quantity);

        /// <summary>
        /// Gets the user basket asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public Task<Basket> GetUserBasketAsync(Guid userId);
    }
}
