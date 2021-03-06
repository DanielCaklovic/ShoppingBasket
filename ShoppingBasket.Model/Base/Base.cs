﻿using ShoppingBasket.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model.Base
{
    /// <summary>
    /// Base model.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Model.Common.IBase" />
    public class Base : IBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }
    }
}
