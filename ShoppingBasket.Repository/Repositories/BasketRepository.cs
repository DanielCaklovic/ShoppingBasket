using AutoMapper;
using ShoppingBasket.DAL.DBContext;
using ShoppingBasket.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingBasket.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ShoppingBasket.Repository
{
    /// <summary>
    /// Basket repository.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.BaseRepository{ShoppingBasket.DAL.Entities.Basket}" />
    /// <seealso cref="ShoppingBasket.Repository.Common.IBasketRepository" />
    public class BasketRepository : BaseRepository<ShoppingBasket.DAL.Entities.Basket>, IBasketRepository
    {
        /// <summary>
        /// The product repository
        /// </summary>
        protected readonly IProductRepository ProductRepository;

        /// <summary>
        /// The basket item repository
        /// </summary>
        protected readonly IBasketItemRepository BasketItemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketRepository" /> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="basketItemRepository">The basket item repository.</param>
        /// <param name="dbContext">The database context.</param>
        /// <param name="mapper">The mapper.</param>
        public BasketRepository(
            IProductRepository productRepository,
            IBasketItemRepository basketItemRepository,
            DatabaseContext dbContext,
            IMapper mapper) : base (dbContext, mapper)
        {
            this.ProductRepository = productRepository;
            this.BasketItemRepository = basketItemRepository;
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<ShoppingBasket.DAL.Entities.Basket> GetByIdAsync(Guid id)
        {
            var entity = await base.GetByIdAsync(id);
            DbContext.Entry(entity).Collection(p => p.Items).Load();
            DbContext.Entry(entity).Collection(p => p.DiscountRules).Load();

            //cannot prefetch products from basket using efcore, find out how to do this
            foreach (var basketItem in entity.Items)
            {
                basketItem.Product = await ProductRepository.GetByIdAsync(basketItem.ProductId);
            }

            return entity;
        }

        /// <summary>
        /// Adds the product to basket.
        /// </summary>
        /// <param name="basket">The basket.</param>
        /// <param name="product">The product.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public async Task<Basket> AddProductToBasket(Basket basket, Product product, int quantity)
        {
            //if product does not exists add new, otherwise update quantity of the existing
            if (!basket.Items.Any(x => x.ProductId == product.Id))
            {
                var basketItem = new BasketItem
                {
                    Id = Guid.NewGuid(),
                    BasketId = basket.Id,
                    ProductId = product.Id,
                    Quantity = quantity,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow
                };

                await BasketItemRepository.CreateAsync(basketItem);
            }
            else
            {
                var basketItem = basket.Items.Find(x => x.ProductId == product.Id);
                basketItem.Quantity += quantity;

                await BasketItemRepository.UpdateAsync(basketItem.Id, basketItem);
            }

            return await GetByIdAsync(basket.Id);
        }

        /// <summary>
        /// Gets the user basket asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<Basket> GetUserBasketAsync(Guid userId)
        {
            var basket = DbContext.Baskets.FirstOrDefault(x => x.UserId == userId);
            DbContext.Entry(basket).Collection(p => p.Items).Load();

            //cannot prefetch products from basket using efcore, find out how to do this
            foreach (var basketItem in basket.Items)
            {
                basketItem.Product = await ProductRepository.GetByIdAsync(basketItem.ProductId);
            }

            return basket;
        }
    }
}
