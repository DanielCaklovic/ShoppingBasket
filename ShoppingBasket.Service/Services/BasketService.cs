using AutoMapper;
using Microsoft.Extensions.Logging;
using ShoppingBasket.DAL.Entities;
using ShoppingBasket.Model.Common;
using ShoppingBasket.Repository.Common;
using ShoppingBasket.Service.Common;
using System;
using System.Threading.Tasks;

namespace ShoppingBasket.Service
{
    /// <summary>
    /// Basket service.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Service.BaseService" />
    /// <seealso cref="ShoppingBasket.Service.Common.IBasketService" />
    public class BasketService : BaseService, IBasketService
    {
        /// <summary>
        /// The basket repository
        /// </summary>
        protected readonly IBasketRepository BasketRepository;

        /// <summary>
        /// The discount service
        /// </summary>
        protected readonly IDiscountService DiscountService;

        /// <summary>
        /// The product service
        /// </summary>
        protected readonly IProductService ProductService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketService"/> class.
        /// </summary>
        /// <param name="basketRepository">The basket repository.</param>
        /// <param name="discountService">The discount service.</param>
        /// <param name="productService">The product service.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public BasketService(IBasketRepository basketRepository,
            IDiscountService discountService,
            IProductService productService,
            IMapper mapper,
            ILogger<BasketService> logger)
            : base (mapper, logger)
        {
            this.BasketRepository = basketRepository;
            this.DiscountService = discountService;
            this.ProductService = productService;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(IBasket model)
        {
            return await BasketRepository.CreateAsync(Mapper.Map<Basket>(model));
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Guid id, IBasket model)
        {
            return await BasketRepository.UpdateAsync(id, Mapper.Map<Basket>(model));
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await BasketRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IBasket> GetByIdAsync(Guid id)
        {
           var entity = await BasketRepository.GetByIdAsync(id);
           return Mapper.Map<IBasket>(entity);
        }

        /// <summary>
        /// Gets the total asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<decimal> GetTotalAsync(Guid id)
        {
            var basket = await ApplyDiscountsAsync(await GetByIdAsync(id));
            return basket.Total;
        }

        /// <summary>
        /// Applies the discounts asynchronous.
        /// </summary>
        /// <param name="basket">The basket.</param>
        /// <returns></returns>
        public async Task<IBasket> ApplyDiscountsAsync(IBasket basket)
        {
            return await DiscountService.ApplyDiscountsAsync(basket);
        }

        /// <summary>
        /// Gets the user basket asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IBasket> GetUserBasketAsync(Guid userId)
        {
            var entity = await BasketRepository.GetUserBasketAsync(userId);
            return Mapper.Map<IBasket>(entity);
        }

        /// <summary>
        /// Adds the product to basket asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public async Task<IBasket> AddProductToBasketAsync(Guid userId, Guid productId, int quantity)
        {
            var basket = await BasketRepository.AddProductToBasket(userId, productId, quantity);
            return await ApplyDiscountsAsync(basket);
        }

        /// <summary>
        /// Deletes the product from basket asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public async Task<IBasket> DeleteProductFromBasketAsync(Guid userId, Guid productId, int quantity)
        {
            var basket = await BasketRepository.DeleteProductFromBasket(userId, productId, quantity);
            return await ApplyDiscountsAsync(basket);
        }
    }
}
