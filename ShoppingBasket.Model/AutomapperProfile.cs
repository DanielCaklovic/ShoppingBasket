using AutoMapper;
using ShoppingBasket.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Model
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
            CreateMap<User, ShoppingBasket.DAL.Entities.User>().ReverseMap();
            CreateMap<Product, ShoppingBasket.DAL.Entities.Product>().ReverseMap();
            CreateMap<DiscountRule, ShoppingBasket.DAL.Entities.DiscountRule>().ReverseMap();
            CreateMap<BasketItem, ShoppingBasket.DAL.Entities.BasketItem>().ReverseMap();
            CreateMap<Basket, ShoppingBasket.DAL.Entities.Basket>().ReverseMap();

            CreateMap<ShoppingBasket.DAL.Entities.Basket, IBasket>().ReverseMap();
            CreateMap<ShoppingBasket.DAL.Entities.BasketItem, IBasketItem>().ReverseMap();
            CreateMap<ShoppingBasket.DAL.Entities.DiscountRule, IDiscountRule>().ReverseMap();
            CreateMap<ShoppingBasket.DAL.Entities.Product, IProduct>().ReverseMap();
            CreateMap<ShoppingBasket.DAL.Entities.User, IUser>().ReverseMap();

        }
    }
}
