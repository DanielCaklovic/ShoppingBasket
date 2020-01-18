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
    /// Discount rule service.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Service.BaseService" />
    /// <seealso cref="ShoppingBasket.Service.Common.IDiscountRuleService" />
    public class DiscountRuleService : BaseService, IDiscountRuleService
    {
        /// <summary>
        /// The discount rule repository
        /// </summary>
        protected readonly IDiscountRuleRepository DiscountRuleRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountRuleService"/> class.
        /// </summary>
        /// <param name="discountRuleRepository">The discount rule repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public DiscountRuleService(IDiscountRuleRepository discountRuleRepository,
                IMapper mapper,
                ILogger<BasketService> logger)
                : base(mapper, logger)
        {
            this.DiscountRuleRepository = discountRuleRepository;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(IDiscountRule model)
        {
            return await DiscountRuleRepository.CreateAsync(Mapper.Map<DiscountRule>(model));
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Guid id, IDiscountRule model)
        {
            return await DiscountRuleRepository.UpdateAsync(id, Mapper.Map<DiscountRule>(model));
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await DiscountRuleRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IDiscountRule> GetByIdAsync(Guid id)
        {
            var entity = await DiscountRuleRepository.GetByIdAsync(id);
            return Mapper.Map<IDiscountRule>(entity);
        }
    }
}
