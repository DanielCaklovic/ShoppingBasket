using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShoppingBasket.API
{
    /// <summary>
    /// Base controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// The mapper
        /// </summary>
        protected readonly IMapper Mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        public BaseController(IMapper mapper)
        {
            this.Mapper = mapper;
        }
    }
}