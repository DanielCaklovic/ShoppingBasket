using ShoppingBasket.DAL.Entities;

namespace ShoppingBasket.Repository.Common
{
    /// <summary>
    /// Product repository contract.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.Common.IBaseRepository{ShoppingBasket.DAL.Entities.Product}" />
    public interface IProductRepository : IBaseRepository<Product>
    {
    }
}
