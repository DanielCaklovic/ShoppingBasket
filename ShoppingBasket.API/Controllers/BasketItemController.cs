using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using log4net.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingBasket.Model;
using ShoppingBasket.Model.Common;
using ShoppingBasket.Service.Common;
using static ShoppingBasket.API.Controllers.ProductController;

namespace ShoppingBasket.API.Controllers
{
    /// <summary>
    /// Basket item controller.
    /// </summary>
    /// <seealso cref="ShoppingBasket.API.BaseController" />
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemController : BaseController
    {
        /// <summary>
        /// The basket item service
        /// </summary>
        private readonly IBasketItemService BasketItemService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketItemController"/> class.
        /// </summary>
        /// <param name="basketItemService">The basket item service.</param>
        /// <param name="mapper">The mapper.</param>
        public BasketItemController(IBasketItemService basketItemService,
                                IMapper mapper)
            : base(mapper)
        {
            this.BasketItemService = basketItemService;
        }

        // GET: api/BasketItem/GUID
        /// <summary>
        /// Gets the basket item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BasketItemREST>> GetBasketItem(Guid id)
        {
            var basketItem = await BasketItemService.GetByIdAsync(id);
            var basketItemREST = Mapper.Map<BasketItemREST>(basketItem);

            if (basketItemREST == null)
            {
                return NotFound();
            }

            return Ok(basketItemREST);
        }

        // PUT: api/BasketItem/GUID
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Puts the basket item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="basketItemREST">The basket item rest.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> PutBasketItem(Guid id, BasketItemREST basketItemREST)
        {
            if (id != basketItemREST.Id)
            {
                return BadRequest();
            }

            var basketItemModel = Mapper.Map<IBasketItem>(basketItemREST);
            bool success = await BasketItemService.UpdateAsync(id, basketItemModel);
            if (!success)
            {
                return NoContent();
            }
            return Ok(success);
        }

        // POST: api/BasketItem
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Posts the basket item.
        /// </summary>
        /// <param name="basketItemREST">The basket item rest.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<BasketItemREST>> PostBasketItem(BasketItemREST basketItemREST)
        {
            var basketItemModel = Mapper.Map<IBasketItem>(basketItemREST);
            var success = await BasketItemService.CreateAsync(basketItemModel);
            if (!success)
            {
                return StatusCode(500);
            }
            return Ok(success);
        }

        // DELETE: api/BasketItem/GUID
        /// <summary>
        /// Deletes the basket item.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteBasketItem(Guid id)
        {
            bool success = await BasketItemService.DeleteAsync(id);
            if (!success)
            {
                return StatusCode(500);
            }
            return Ok(success);
        }

        //TODO excude sensitive data
        /// <summary>
        /// Basket item rest model.
        /// </summary>
        public class BasketItemREST
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>
            /// The identifier.
            /// </value>
            public Guid Id { get; set; }
            /// <summary>
            /// Gets or sets the basket identifier.
            /// </summary>
            /// <value>
            /// The basket identifier.
            /// </value>
            public Guid BasketId { get; set; }
            /// <summary>
            /// Gets or sets the product.
            /// </summary>
            /// <value>
            /// The product.
            /// </value>
            public ProductREST Product { get; set; }

            /// <summary>
            /// Gets or sets the product identifier.
            /// </summary>
            /// <value>
            /// The product identifier.
            /// </value>
            public Guid ProductId { get; set; }
            /// <summary>
            /// Gets or sets the quantity.
            /// </summary>
            /// <value>
            /// The quantity.
            /// </value>
            public int Quantity { get; set; }
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