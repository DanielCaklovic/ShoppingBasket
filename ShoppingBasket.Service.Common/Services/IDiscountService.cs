using ShoppingBasket.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasket.Service.Common
{
    /// <summary>
    /// Discount service contract.
    /// </summary>
    public interface IDiscountService
    {
        /// <summary>
        /// Applies the discounts asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public Task<IBasket> ApplyDiscountsAsync(IBasket model);
    }
}
