using ShoppingBasket.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model
{
    /// <summary>
    /// Baskwt item model.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Model.Common.IBasketItem" />
    public class BasketItem : IBasketItem
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
        /// Gets or sets the basket.
        /// </summary>
        /// <value>
        /// The basket.
        /// </value>
        public IBasket Basket { get; set; }
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public IProduct Product { get; set; }

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
