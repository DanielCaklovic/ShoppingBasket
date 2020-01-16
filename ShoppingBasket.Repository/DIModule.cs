using ShoppingBasket.Repository;
using ShoppingBasket.Repository.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Service collection extensions.
    /// </summary>
    public static class IServiceCollectionExtension
    {
        /// <summary>
        /// Adds the repositories.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IBasketItemRepository, BasketItemRepository>();
            services.AddTransient<IDiscountRuleRepository, DiscountRuleRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            return services;
        }
    }
}