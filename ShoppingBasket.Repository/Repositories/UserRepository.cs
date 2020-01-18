using AutoMapper;
using ShoppingBasket.DAL.DBContext;
using ShoppingBasket.DAL.Entities;
using ShoppingBasket.Repository.Common;

namespace ShoppingBasket.Repository
{

    /// <summary>
    /// User repository.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.BaseRepository{ShoppingBasket.DAL.Entities.User}" />
    /// <seealso cref="ShoppingBasket.Repository.Common.IUserRepository" />
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        /// <param name="mapper">The mapper.</param>
        public UserRepository(DatabaseContext databaseContext,
                IMapper mapper) : base(databaseContext, mapper)
        {

        }
    }
}
