using AutoMapper;
using Microsoft.Extensions.Logging;
using ShoppingBasket.Model;
using ShoppingBasket.Model.Common;
using ShoppingBasket.Repository.Common;
using ShoppingBasket.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Service
{
    /// <summary>
    /// Basket item service.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Service.BaseService" />
    /// <seealso cref="ShoppingBasket.Service.Common.IBasketItemService" />
    public class BasketItemService : BaseService, IBasketItemService
    {
        /// <summary>
        /// The basket item repository
        /// </summary>
        protected readonly IBasketItemRepository BasketItemRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketItemService"/> class.
        /// </summary>
        /// <param name="basketItemRepository">The basket item repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public BasketItemService(IBasketItemRepository basketItemRepository,
            IMapper mapper,
            ILogger<BasketItemService> logger)
            : base (mapper, logger)
        {
            this.BasketItemRepository = basketItemRepository;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(IBasketItem model)
        {
            var entity = Mapper.Map<ShoppingBasket.DAL.Entities.BasketItem>(model);
            return await BasketItemRepository.CreateAsync(entity);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Guid id, IBasketItem model)
        {
            var entity = Mapper.Map<ShoppingBasket.DAL.Entities.BasketItem>(model);
            return await BasketItemRepository.UpdateAsync(id, entity);
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await BasketItemRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IBasketItem> GetByIdAsync(Guid id)
        {
           var entity = await BasketItemRepository.GetByIdAsync(id);
           return Mapper.Map<IBasketItem>(entity);
        }
    }
}
