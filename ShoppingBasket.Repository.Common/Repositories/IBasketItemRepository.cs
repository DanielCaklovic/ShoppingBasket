using ShoppingBasket.DAL.Entities;

namespace ShoppingBasket.Repository.Common
{
    /// <summary>
    /// Basket item repository contract.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.Common.IBaseRepository{ShoppingBasket.Model.Common.IBasketItem}" />
    public interface IBasketItemRepository : IBaseRepository<BasketItem>
    {
    }
}
