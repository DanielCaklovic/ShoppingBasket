using ShoppingBasket.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model
{
    /// <summary>
    /// Applied discount model.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Model.Common.IAppliedDiscount" />
    public class AppliedDiscount : IAppliedDiscount
    {
        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the total discount.
        /// </summary>
        /// <value>
        /// The total discount.
        /// </value>
        public decimal TotalDiscount { get; set; }
    }
}
