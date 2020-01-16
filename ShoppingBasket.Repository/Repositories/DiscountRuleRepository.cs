using AutoMapper;
using ShoppingBasket.DAL.DBContext;
using ShoppingBasket.Model;
using ShoppingBasket.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Repository
{
    /// <summary>
    /// Discount rule repository.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.BaseRepository{ShoppingBasket.DAL.Entities.DiscountRule}" />
    /// <seealso cref="ShoppingBasket.Repository.Common.IDiscountRuleRepository" />
    public class DiscountRuleRepository : BaseRepository<ShoppingBasket.DAL.Entities.DiscountRule>, IDiscountRuleRepository
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
