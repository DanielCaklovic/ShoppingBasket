using AutoMapper;
using ShoppingBasket.DAL.DBContext;
using ShoppingBasket.DAL.Entities;
using ShoppingBasket.Repository.Common;

namespace ShoppingBasket.Repository
{
    /// <summary>
    /// Product repository.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.BaseRepository{ShoppingBasket.DAL.Entities.Product}" />
    /// <seealso cref="ShoppingBasket.Repository.Common.IProductRepository" />
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="databaseContext">The database context.</param>
        /// <param name="mapper">The mapper.</param>
        public ProductRepository(DatabaseContext databaseContext,
            IMapper mapper) : base(databaseContext, mapper)
        {

        }
    }
}
