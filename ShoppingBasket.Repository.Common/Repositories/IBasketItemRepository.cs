
using ShoppingBasket.DAL.Entities;

namespace ShoppingBasket.Repository.Common
{
    /// <summary>
    /// Basket item repository contract.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.Common.IBaseRepository{ShoppingBasket.DAL.Entities.BasketItem}" />
    public interface IBasketItemRepository : IBaseRepository<BasketItem>
    {
    }
}
