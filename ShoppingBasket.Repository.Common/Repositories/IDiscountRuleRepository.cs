using ShoppingBasket.DAL.Entities;
using ShoppingBasket.Model.Common;

namespace ShoppingBasket.Repository.Common
{
    /// <summary>
    /// Discount rule repository contract.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.Common.IBaseRepository{ShoppingBasket.DAL.Entities.DiscountRule}" />
    public interface IDiscountRuleRepository : IBaseRepository<DiscountRule>
    {
    }
}
