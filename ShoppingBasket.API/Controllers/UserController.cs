using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingBasket.Model;
using ShoppingBasket.Service.Common;

namespace ShoppingBasket.API.Controllers
{
    /// <summary>
    /// User controller.
    /// </summary>
    /// <seealso cref="ShoppingBasket.API.BaseController" />
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        /// <summary>
        /// The user service
        /// </summary>
        private readonly IUserService UserService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        /// <param name="mapper">The mapper.</param>
        public UserController(IUserService userService,
                                      IMapper mapper)
                  : base(mapper)
        {
            this.UserService = userService;
        }

        // GET: api/User/GUID
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserREST>> GetUser(Guid id)
        {
            var model = await UserService.GetByIdAsync(id);
            var productREST = Mapper.Map<UserREST>(model);

            if (productREST == null)
            {
                return NotFound();
            }

            return Ok(productREST);
        }

        // PUT: api/User/GUID
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Puts the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="userREST">The user rest.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> PutUser(Guid id, UserREST userREST)
        {
            if (id != userREST.Id)
            {
                return BadRequest();
            }

            var userModel = Mapper.Map<User>(userREST);

            bool success = await UserService.UpdateAsync(id, userModel);
            if (!success)
            {
                return NoContent();
            }
            return Ok(success);
        }

        // POST: api/User
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        /// <summary>
        /// Posts the user.
        /// </summary>
        /// <param name="userREST">The user rest.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserREST>> PostUser(UserREST userREST)
        {
            var userModel = Mapper.Map<User>(userREST);
            var success = await UserService.CreateAsync(userModel);
            if (!success)
            {
                return StatusCode(500);
            }
            return Ok(success);
        }

        // DELETE: api/User/GUID
        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteUser(Guid id)
        {
            bool success = await UserService.DeleteAsync(id);
            if (!success)
            {
                return StatusCode(500);
            }
            return Ok(success);
        }

        /// <summary>
        /// User rest model.
        /// </summary>
        public class UserREST
        {
            /// <summary>
            /// Gets or sets the identifier.
            /// </summary>
            /// <value>
            /// The identifier.
            /// </value>
            public Guid Id { get; set; }
            /// <summary>
            /// Gets or sets the firstname.
            /// </summary>
            /// <value>
            /// The firstname.
            /// </value>
            public string Firstname { get; set; }

            /// <summary>
            /// Gets or sets the lastname.
            /// </summary>
            /// <value>
            /// The lastname.
            /// </value>
            public string Lastname { get; set; }

            /// <summary>
            /// Gets or sets the username.
            /// </summary>
            /// <value>
            /// The username.
            /// </value>
            public string Username { get; set; }

            /// <summary>
            /// Gets or sets the email.
            /// </summary>
            /// <value>
            /// The email.
            /// </value>
            public string Email { get; set; }

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
