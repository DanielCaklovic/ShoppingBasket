using AutoMapper;
using ShoppingBasket.DAL.DBContext;
using ShoppingBasket.DAL.Entities;
using ShoppingBasket.Model.Common;
using ShoppingBasket.Repository.Common;

namespace ShoppingBasket.Repository
{
    /// <summary>
    /// Basket item repository.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.BaseRepository{ShoppingBasket.DAL.Entities.BasketItem}" />
    /// <seealso cref="ShoppingBasket.Repository.Common.IBasketItemRepository" />
    public class BasketItemRepository : BaseRepository<BasketItem>, IBasketItemRepository
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
