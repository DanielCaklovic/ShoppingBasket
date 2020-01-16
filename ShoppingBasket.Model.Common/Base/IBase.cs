using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model.Common
{
    /// <summary>
    /// Base model contract.
    /// </summary>
    public interface IBase
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
