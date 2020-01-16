using AutoMapper;
using ShoppingBasket.Model;
using ShoppingBasket.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ShoppingBasket.API.Controllers.BasketController;
using static ShoppingBasket.API.Controllers.BasketItemController;
using static ShoppingBasket.API.Controllers.DiscountRuleController;
using static ShoppingBasket.API.Controllers.ProductController;
using static ShoppingBasket.API.Controllers.UserController;

namespace ShoppingBasket.API
{
    /// <summary>
    /// Automapper configuration.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile()
        {
            CreateMap<BasketREST, Basket>().ReverseMap();
            CreateMap<BasketItemREST, BasketItem>().ReverseMap();
            CreateMap<DiscountRuleREST, DiscountRule>().ReverseMap();
            CreateMap<ProductREST, Product>().ReverseMap();
            CreateMap<UserREST, User>().ReverseMap();

            CreateMap<BasketREST, IBasket>().ReverseMap();
            CreateMap<BasketItemREST, IBasketItem>().ReverseMap();
            CreateMap<DiscountRuleREST, IDiscountRule>().ReverseMap();
            CreateMap<ProductREST, IProduct>().ReverseMap();
            CreateMap<UserREST, IUser>().ReverseMap();
        }
    }
}
