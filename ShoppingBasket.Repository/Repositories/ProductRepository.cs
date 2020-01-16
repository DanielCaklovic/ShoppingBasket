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
    /// Prodcut repository.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Repository.BaseRepository{ShoppingBasket.DAL.Entities.Product}" />
    /// <seealso cref="ShoppingBasket.Repository.Common.IProductRepository" />
    public class ProductRepository : BaseRepository<ShoppingBasket.DAL.Entities.Product>, IProductRepository
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
