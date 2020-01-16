using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingBasket.Model;
using ShoppingBasket.Model.Common;
using ShoppingBasket.Service.Common;
using static ShoppingBasket.API.Controllers.ProductController;

namespace ShoppingBasket.API.Controllers
{
    /// <summary>
    /// Discount rule controller.
    /// </summary>
    /// <seealso cref="ShoppingBasket.API.BaseController" />
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountRuleController : BaseController
    {
        /// <summary>
        /// The discount rule service
        /// </summary>
        private readonly IDiscountRuleService DiscountRuleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountRuleController"/> class.
        /// </summary>
        /// <param name="discountRuleService">The discount rule service.</param>
        /// <param name="mapper">The mapper.</param>
        public DiscountRuleController(IDiscountRuleService discountRuleService,
                                IMapper mapper)
            : base(mapper)
        {
            this.DiscountRuleService = discountRuleService;
        }

        // GET: api/DiscountRule/GUID
        /// <summary>
        /// Gets the discount rule.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DiscountRuleREST>> GetDiscountRule(Guid id)
        {
            var discountRule = await DiscountRuleService.GetByIdAsync(id);
            var discountRuleREST = Mapper.Map<DiscountRuleREST>(discountRule);

            if (discountRuleREST == null)
            {
                return NotFound();
            }

            return Ok(discountRuleREST);
        }

        // PUT: api/DiscountRule/GUID
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Puts the discount rule.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="discountRuleREST">The discount rule rest.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> PutDiscountRule(Guid id, DiscountRuleREST discountRuleREST)
        {
            if (id != discountRuleREST.Id)
            {
                return BadRequest();
            }

            var discountRuleModel = Mapper.Map<DiscountRule>(discountRuleREST);

            bool success = await DiscountRuleService.UpdateAsync(id, discountRuleModel);
            if (!success)
            {
                return NoContent();
            }
            return Ok(success);
        }

        // POST: api/DiscountRule
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Posts the discount rule.
        /// </summary>
        /// <param name="discountRuleREST">The discount rule rest.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DiscountRuleREST>> PostDiscountRule(DiscountRuleREST discountRuleREST)
        {
            var discountRuleModel = Mapper.Map<DiscountRule>(discountRuleREST);
            var success = await DiscountRuleService.CreateAsync(discountRuleModel);
            if (!success)
            {
                return StatusCode(500);
            }
            return Ok(success);
        }

        // DELETE: api/DiscountRule/GUID
        /// <summary>
        /// Deletes the discount rule.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteDiscountRule(Guid id)
        {
            bool success = await DiscountRuleService.DeleteAsync(id);
            if (!success)
            {
                return StatusCode(500);
            }
            return Ok(success);
        }

        /// <summary>
        /// Discount rule rest model.
        /// </summary>
        public class DiscountRuleREST
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>
            /// The identifier.
            /// </value>
            public Guid Id { get; set; }
            /// <summary>
            /// Gets or sets the product.
            /// </summary>
            /// <value>
            /// The product.
            /// </value>
            public ProductREST Product { get; set; }

            /// <summary>
            /// Gets or sets the discount product.
            /// </summary>
            /// <value>
            /// The discount product.
            /// </value>
            public ProductREST DiscountProduct { get; set; }
            /// <summary>
            /// Gets or sets the quantity.
            /// </summary>
            /// <value>
            /// The quantity.
            /// </value>
            public int Quantity { get; set; }

            /// <summary>
            /// Gets or sets the percentage.
            /// </summary>
            /// <value>
            /// The percentage.
            /// </value>
            public decimal Percentage { get; set; }
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