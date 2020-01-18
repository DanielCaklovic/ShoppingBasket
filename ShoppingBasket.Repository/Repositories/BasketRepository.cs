using AutoMapper;
using ShoppingBasket.DAL.DBContext;
using ShoppingBasket.Repository.Common;
using System;
using System.Linq;
using System.Threading.Tasks;
using ShoppingBasket.Model.Common;
using ShoppingBasket.DAL.Entities;

namespace ShoppingBasket.Repository
{
    /// <summary>
    /// Basket repository.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.BaseRepository{ShoppingBasket.DAL.Entities.Basket}" />
    /// <seealso cref="ShoppingBasket.Repository.Common.IBasketRepository" />
    public class BasketRepository : BaseRepository<Basket>, IBasketRepository
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
        public async Task<IBasket> GetByIdAsync(Guid id)
        {
            var entity = await base.GetByIdAsync(id);
            if(entity != null)
            {
                DbContext.Entry(entity).Collection(p => p.Items).Load();
                DbContext.Entry(entity).Collection(p => p.DiscountRules).Load();

                //cannot prefetch products from basket using efcore, find out how to do this
                foreach (var basketItem in entity.Items)
                {
                    basketItem.Product = await ProductRepository.GetByIdAsync(basketItem.ProductId);
                }
            }

            return Mapper.Map<IBasket>(entity);
        }

        /// <summary>
        /// Adds the product to basket.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public async Task<IBasket> AddProductToBasket(Guid userId, Guid productId, int quantity)
        {
            var basket = await GetUserBasketAsync(userId);
            var product = await ProductRepository.GetByIdAsync(productId);
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
                var basketEntity = await GetByIdAsync(basket.Id);
                var basketItem = basketEntity.Items.Find(x => x.ProductId == product.Id);

                var basketItemEntity = await BasketItemRepository.GetByIdAsync(basketItem.Id);
                basketItemEntity.Quantity += quantity;
                basketItemEntity.DateUpdated = DateTime.UtcNow;

                await BasketItemRepository.UpdateAsync(basketItemEntity.Id, basketItemEntity);
            }

            return await GetByIdAsync(basket.Id);
        }

        /// <summary>
        /// Gets the user basket asynchronous.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public async Task<IBasket> GetUserBasketAsync(Guid userId)
        {
            var entity = DbContext.Baskets.FirstOrDefault(x => x.UserId == userId);
            if(entity != null)
            {
                DbContext.Entry(entity).Collection(p => p.Items).Load();

                //TODO: cannot prefetch products from basket using efcore, find out how to do this
                foreach (var basketItem in entity.Items)
                {
                    basketItem.Product = await ProductRepository.GetByIdAsync(basketItem.ProductId);
                }
            }

            return Mapper.Map<IBasket>(entity);
        }

        /// <summary>
        /// Deletes the product from basket.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="productId">The product identifier.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns></returns>
        public async Task<IBasket> DeleteProductFromBasket(Guid userId, Guid productId, int quantity)
        {
            var basket = await GetUserBasketAsync(userId);
            var product = await ProductRepository.GetByIdAsync(productId);

            var basketEntity = await GetByIdAsync(basket.Id);
            var basketItem = basketEntity.Items.Find(x => x.ProductId == product.Id);

            //delete product from basket
            if(basketItem.Quantity == quantity)
            {
                await BasketItemRepository.DeleteAsync(basketItem.Id);
            }
            else
            {
                //update quantity
                var basketItemEntity = await BasketItemRepository.GetByIdAsync(basketItem.Id);
                basketItemEntity.Quantity -= quantity;
                basketItemEntity.DateUpdated = DateTime.UtcNow;
                await BasketItemRepository.UpdateAsync(basketItemEntity.Id, basketItemEntity);
            }

            return await GetByIdAsync(basket.Id);
        }
    }
}
