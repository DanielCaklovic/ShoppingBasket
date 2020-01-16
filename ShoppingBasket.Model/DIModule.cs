using Microsoft.Extensions.DependencyInjection;
using ShoppingBasket.Model;
using ShoppingBasket.Model.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Service collection extensions.
    /// </summary>
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Adds the models.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddModels(this IServiceCollection services)
        {
            services.AddTransient<IUser, User>();
            services.AddTransient<IProduct, Product>();
            services.AddTransient<IDiscountRule, DiscountRule>();
            services.AddTransient<IBasketItem, BasketItem>();
            services.AddTransient<IBasket, Basket>();
            return services;
        }
    }
}
