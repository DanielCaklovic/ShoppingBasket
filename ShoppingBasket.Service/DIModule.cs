
using ShoppingBasket.Service;
using ShoppingBasket.Service.Common;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBaseService, BaseService>();
            services.AddTransient<IBasketService, BasketService>();
            services.AddTransient<IBasketItemService, BasketItemService>();
            services.AddTransient<IDiscountRuleService, DiscountRuleService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDiscountService, DiscountService>();
            return services;
        }
    }
}