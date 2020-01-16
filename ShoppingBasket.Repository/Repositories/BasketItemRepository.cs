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
    /// Basket item repository.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.BaseRepository{ShoppingBasket.DAL.Entities.BasketItem}" />
    /// <seealso cref="ShoppingBasket.Repository.Common.IBasketItemRepository" />
    public class BasketItemRepository : BaseRepository<ShoppingBasket.DAL.Entities.BasketItem>, IBasketItemRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasketItemRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="mapper">The mapper.</param>
        public BasketItemRepository(
                    DatabaseContext dbContext,
                    IMapper mapper) : base(dbContext, mapper)
        {

        }
    }
}
