using AutoMapper;
using ShoppingBasket.DAL.DBContext;
using ShoppingBasket.DAL.Entities;
using ShoppingBasket.Repository.Common;

namespace ShoppingBasket.Repository
{
    /// <summary>
    /// Discount rule repository.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.BaseRepository{ShoppingBasket.DAL.Entities.DiscountRule}" />
    /// <seealso cref="ShoppingBasket.Repository.Common.IDiscountRuleRepository" />
    public class DiscountRuleRepository : BaseRepository<DiscountRule>, IDiscountRuleRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountRuleRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="mapper">The mapper.</param>
        public DiscountRuleRepository(
            DatabaseContext dbContext,
            IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
