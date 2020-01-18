using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingBasket.API.Requests;
using ShoppingBasket.Model;
using ShoppingBasket.Model.Common;
using ShoppingBasket.Service.Common;
using static ShoppingBasket.API.Controllers.BasketItemController;
using static ShoppingBasket.API.Controllers.DiscountRuleController;

namespace ShoppingBasket.API.Controllers
{
    /// <summary>
    /// Basket controller.
    /// </summary>
    /// <seealso cref="ShoppingBasket.API.BaseController" />
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : BaseController
    {
        /// <summary>
        /// The basket service
        /// </summary>
        private readonly IBasketService BasketService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketController"/> class.
        /// </summary>
        /// <param name="basketService">The basket service.</param>
        /// <param name="mapper">The mapper.</param>
        public BasketController(IBasketService basketService,
                                IMapper mapper)
            : base(mapper)
        {
            this.BasketService = basketService;
        }

        // GET: api/Basket/GUID
        /// <summary>
        /// Gets the basket.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BasketREST>> GetBasket(Guid id)
        {
            var basket = await BasketService.GetByIdAsync(id);
            var basketREST = Mapper.Map<BasketREST>(basket);

            if (basketREST == null)
            {
                return NotFound();
            }

            return Ok(basketREST);
        }

        // PUT: api/Basket/GUID
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Puts the basket.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="basketREST">The basket rest.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> PutBasket(Guid id, BasketREST basketREST)
        {
            if (id != basketREST.Id)
            {
                return BadRequest();
            }

            var basketModel = Mapper.Map<Basket>(basketREST);
            bool success = await BasketService.UpdateAsync(id, basketModel);
            if (!success)
            {
                return NoContent();
            }
            return Ok(success);
        }

        // POST: api/Basket
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Posts the basket.
        /// </summary>
        /// <param name="basketREST">The basket rest.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BasketREST>> PostBasket(BasketREST basketREST)
        {
            var basketModel = Mapper.Map<Basket>(basketREST);
            var success = await BasketService.CreateAsync(basketModel);
            if (!success)
            {
                return StatusCode(500);
            }
            return Ok(success);
        }

        // DELETE: api/Basket/GUID
        /// <summary>
        /// Deletes the basket.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteBasket(Guid id)
        {
            bool success = await BasketService.DeleteAsync(id);
            if (!success)
            {
                return StatusCode(500);
            }
            return Ok(success);
        }

        // GET: api/Basket/get-total/GUID
        /// <summary>
        /// Gets the total asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("get-total/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<decimal>> GetTotalAsync(Guid id)
        {
            var total = await BasketService.GetTotalAsync(id);
            return Ok(total);
        }

        // POST: api/Basket/add-product-to-basket/
        /// <summary>
        /// Adds the product to basket asynchronous.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        [HttpPost("add-product-to-basket")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BasketREST>> AddProductToBasketAsync([FromBody]AddProductToBasketRequest data)
        {
            if (data.UserId == Guid.Empty ||
                data.ProductId == Guid.Empty ||
                data.Quantity == 0)
            {
                return BadRequest("Invalid parameters");
            }

            var basketModel = await BasketService.AddProductToBasketAsync(data.UserId, data.ProductId, data.Quantity);
            var basketREST = Mapper.Map<BasketREST>(basketModel);

            return Ok(basketREST);
        }

        // DELETE: api/Basket/delete-product-from-basket/
        [HttpDelete("delete-product-from-basket")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BasketREST>> DeleteProductFromBasketAsync([FromBody]DeleteProductFromBasketRequest data)
        {
            var basketModel = await BasketService.DeleteProductFromBasketAsync(data.UserId, data.ProductId, data.Quantity);
            var basketREST = Mapper.Map<BasketREST>(basketModel);

            return Ok(basketREST);
        }

        /// <summary>
        /// Basket rest model.
        /// </summary>
        public class BasketREST
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>
            /// The identifier.
            /// </value>
            public Guid Id { get; set; }
            /// <summary>
            /// Gets or sets the items.
            /// </summary>
            /// <value>
            /// The items.
            /// </value>
            public List<BasketItemREST> Items { get; set; }

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

            /// <summary>
            /// Gets or sets the user identifier.
            /// </summary>
            /// <value>
            /// The user identifier.
            /// </value>
            public Guid UserId { get; set; }
            /// <summary>
            /// Gets or sets the total.
            /// </summary>
            /// <value>
            /// The total.
            /// </value>
            public decimal Total { get; set; }

            /// <summary>
            /// Gets or sets the applied discounts.
            /// </summary>
            /// <value>
            /// The applied discounts.
            /// </value>
            public List<AppliedDiscount> AppliedDiscounts { get; set; }
        }
    }
}