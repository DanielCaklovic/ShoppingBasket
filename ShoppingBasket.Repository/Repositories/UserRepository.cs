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
    /// User repository.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.BaseRepository{ShoppingBasket.DAL.Entities.User}" />
    /// <seealso cref="ShoppingBasket.Repository.Common.IUserRepository" />
    public class UserRepository : BaseRepository<ShoppingBasket.DAL.Entities.User>, IUserRepository
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
