using AutoMapper;
using Microsoft.Extensions.Logging;
using ShoppingBasket.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Service
{
    /// <summary>
    /// Base service.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Service.Common.IBaseModelService" />
    public class BaseService : IBaseService
    {
        /// <summary>
        /// The mapper
        /// </summary>
        protected readonly IMapper Mapper;

        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger<BaseService> Logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public BaseService(IMapper mapper, ILogger<BaseService> logger)
        {
            this.Mapper = mapper;
            this.Logger = logger;
        }
    }
}
