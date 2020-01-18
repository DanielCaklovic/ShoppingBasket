using ShoppingBasket.DAL.Entities;
using ShoppingBasket.Model.Common;

namespace ShoppingBasket.Repository.Common
{

    /// <summary>
    /// User repository contract.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.Common.IBaseRepository{ShoppingBasket.DAL.Entities.User}" />
    public interface IUserRepository : IBaseRepository<User>
    {

    }
}
