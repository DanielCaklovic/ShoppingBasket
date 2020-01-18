using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model.Common
{
    /// <summary>
    /// Discount rule contract.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Model.Common.IBaseModel" />
    public interface IDiscountRule : IBaseModel
    {
        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public IProduct Product { get; set; }

        /// <summary>
        /// Gets or sets the discount product.
        /// </summary>
        /// <value>
        /// The discount product.
        /// </value>
        public IProduct DiscountProduct { get; set; }

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
