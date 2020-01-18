using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model.Common
{
    /// <summary>
    /// Basket model contract.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Model.Common.IBaseModel" />
    public interface IBasket : IBaseModel
    {
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public List<IBasketItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the discount rules.
        /// </summary>
        /// <value>
        /// The discount rules.
        /// </value>
        public List<IDiscountRule> DiscountRules { get; set; }
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

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid UserId { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        public IUser User { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        /// <value>
        /// The total.
        /// </value>
        public decimal Total { get; set; }

        /// <summary>
        /// Gets or sets the applied discounts.
        /// </summary>
        /// <value>
        /// The applied discounts.
        /// </value>
        public List<IAppliedDiscount> AppliedDiscounts { get; set; }
    }
}
