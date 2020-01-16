using AutoMapper;
using Microsoft.Extensions.Logging;
using ShoppingBasket.Model.Common;
using ShoppingBasket.Repository.Common;
using ShoppingBasket.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Service
{
    /// <summary>
    /// Product service.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Service.BaseService" />
    /// <seealso cref="ShoppingBasket.Service.Common.IProductService" />
    public class ProductService : BaseService, IProductService
    {
        /// <summary>
        /// The product repository
        /// </summary>
        protected readonly IProductRepository ProductRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public ProductService(IProductRepository productRepository,
            IMapper mapper,
            ILogger<ProductService> logger)
            : base (mapper, logger)
        {
            this.ProductRepository = productRepository;
        }

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> CreateAsync(IProduct model)
        {
            var entity = Mapper.Map<ShoppingBasket.DAL.Entities.Product>(model);
            return await ProductRepository.CreateAsync(entity);
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Guid id, IProduct model)
        {
            var entity = Mapper.Map<ShoppingBasket.DAL.Entities.Product>(model);
            return await ProductRepository.UpdateAsync(id, entity);
        }

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await ProductRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<IProduct> GetByIdAsync(Guid id)
        {
            var entity = await ProductRepository.GetByIdAsync(id);
            return Mapper.Map<IProduct>(entity);
        }
    }
}
