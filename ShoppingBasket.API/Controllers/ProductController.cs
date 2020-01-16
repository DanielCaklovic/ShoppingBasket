using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.Model;
using ShoppingBasket.Service.Common;

namespace ShoppingBasket.API.Controllers
{
    /// <summary>
    /// Product controller.
    /// </summary>
    /// <seealso cref="ShoppingBasket.API.BaseController" />
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        /// <summary>
        /// The product service
        /// </summary>
        private readonly IProductService ProductService;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        /// <param name="mapper">The mapper.</param>
        public ProductController(IProductService productService,
                                      IMapper mapper)
                  : base(mapper)
        {
            this.ProductService = productService;
        }

        // GET: api/Product/GUID
        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductREST>> GetProduct(Guid id)
        {
            var product = await ProductService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Product/GUID
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Puts the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="productREST">The product rest.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> PutProduct(Guid id, ProductREST productREST)
        {
            if (id != productREST.Id)
            {
                return BadRequest();
            }

            var productModel = Mapper.Map<Product>(productREST);

            bool success = await ProductService.UpdateAsync(id, productModel);
            if (!success)
            {
                return NoContent();
            }
            return Ok(success);
        }

        // POST: api/Product
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Posts the product.
        /// </summary>
        /// <param name="productREST">The product rest.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProductREST>> PostProduct(ProductREST productREST)
        {
            var productModel = Mapper.Map<Product>(productREST);
            var success = await ProductService.CreateAsync(productModel);
            if (!success)
            {
                return StatusCode(500);
            }
            return Ok(success);
        }

        // DELETE: api/Product/GUID
        /// <summary>
        /// Deletes the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteProduct(Guid id)
        {
            bool success = await ProductService.DeleteAsync(id);
            if (!success)
            {
                return StatusCode(500);
            }
            return Ok(success);
        }

        /// <summary>
        /// Product rest model.
        /// </summary>
        public class ProductREST
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>
            /// The identifier.
            /// </value>
            public Guid Id { get; set; }
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>
            /// The name.
            /// </value>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets the slug.
            /// </summary>
            /// <value>
            /// The slug.
            /// </value>
            public string Slug { get; set; }
            /// <summary>
            /// Gets or sets the price.
            /// </summary>
            /// <value>
            /// The price.
            /// </value>
            public decimal Price { get; set; }

            /// <summary>
            /// Gets or sets the date created.
            /// </summary>
            /// <value>
            /// The date created.
            /// </value>
            public DateTime DateCreated { get; set; }

            /// <summary>
            /// Gets or sets the date updated.
            /// </summary>
            /// <value>
            /// The date updated.
            /// </value>
            public DateTime DateUpdated { get; set; }
        }
    }
}