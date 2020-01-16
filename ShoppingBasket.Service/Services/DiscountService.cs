using ShoppingBasket.Model.Common;
using ShoppingBasket.Service.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using AutoMapper;
using ShoppingBasket.Model;

namespace ShoppingBasket.Service
{
    /// <summary>
    /// Discount service.
    /// </summary>
    /// <seealso cref="ShoppingBasket.Service.BaseService" />
    /// <seealso cref="ShoppingBasket.Service.Common.IDiscountService" />
    public class DiscountService : BaseService, IDiscountService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="logger">The logger.</param>
        public DiscountService(IMapper mapper, ILogger<DiscountService> logger)
            : base (mapper, logger)
        {

        }

        /// <summary>
        /// Applies the discounts asynchronous.
        /// </summary>
        /// <param name="basket">The basket.</param>
        /// <returns></returns>
        public async Task<IBasket> ApplyDiscountsAsync(IBasket basket)
        {
            decimal totalDiscount = 0;

            basket.AppliedDiscounts = new List<IAppliedDiscount>();
            StringBuilder sbLog = new StringBuilder();

            foreach (var basketItem in basket.Items)
            {
                string discountInfo = string.Empty;
                if (basket.DiscountRules.Any(rule => rule.Product.Id == basketItem.Product.Id &&
                                                                        basketItem.Quantity >= rule.Quantity))
                {
                    var discountRule = basket.DiscountRules.Find(rule => rule.Product.Id == basketItem.Product.Id &&
                                                                                            basketItem.Quantity >= rule.Quantity);
                    var discountPercentage = discountRule.Percentage / 100;
                    var applicableDiscountCount = basketItem.Quantity / discountRule.Quantity;
                    var discountedPrice = discountRule.DiscountProduct.Price * discountPercentage;
                    var discountToApply = applicableDiscountCount * discountedPrice;
                    totalDiscount += discountToApply;

                    discountInfo = String.Format("DiscountRule: {0}, ApplicableDiscount: (Items: {1}, ItemDiscountedPrice: {2}$), AppliedDiscount: {3}$",
                        discountRule.Name,
                        applicableDiscountCount,
                        discountedPrice,
                        discountToApply);

                    basket.AppliedDiscounts.Add(new AppliedDiscount
                    {
                        Name = discountRule.Name,
                        Quantity = applicableDiscountCount,
                        TotalDiscount = discountToApply
                    });

                    sbLog.AppendFormat("Product: {0}, Price: {1}$, Quantity: {2}, Discount: ({3})", basketItem.Product.Name,
                                                                                            basketItem.Product.Price,
                                                                                            basketItem.Quantity,
                                                                                            discountInfo);
                }
                else
                {
                    sbLog.AppendFormat("Product: {0}, Price: {1}$, Quantity: {2}, Discount: No discount", basketItem.Product.Name,
                                                                                           basketItem.Product.Price,
                                                                                           basketItem.Quantity);
                }

                sbLog.Append(Environment.NewLine);
            }

            var totalSum = basket.Items.Where(x => x.Quantity > 0)
                                       .Select(x => x.Product.Price * x.Quantity)
                                       .Sum();
            var total = Math.Round(totalSum - totalDiscount, 2);
            basket.Total = total;

            string logInfo = String.Format("Total basket sum: {0}$, Total discount: {1}$, Basket contents:\n{2}", total, totalDiscount, sbLog.ToString());
            Logger.LogInformation(logInfo);

            return basket;
        }
    }
}
