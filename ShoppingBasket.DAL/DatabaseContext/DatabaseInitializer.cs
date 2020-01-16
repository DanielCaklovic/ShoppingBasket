using Microsoft.EntityFrameworkCore;
using ShoppingBasket.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasket.DAL
{
    /// <summary>
    /// Database initializer.
    /// </summary>
    public static class DatabaseInitializer
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public static void Initialize(DatabaseContext context)
        {
            context.Database.EnsureCreated();

            var testUser = new Entities.User
            {
                Id = Guid.NewGuid(),
                Firstname = "test",
                Lastname = "user",
                Email = "testuser@test.com",
                Username = "testuser",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            //users
            if(!context.Users.Any())
            {
                context.Users.Add(testUser);
            }

            //products
            var breadEntity = new Entities.Product
            {
                Id = Guid.NewGuid(),
                Name = "bread",
                Slug = "bread",
                Price = 1,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            var butterEntity = new Entities.Product
            {
                Id = Guid.NewGuid(),
                Name = "butter",
                Slug = "butter",
                Price = 0.8m,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            var milkEntity = new Entities.Product
            {
                Id = Guid.NewGuid(),
                Name = "milk",
                Slug = "milk",
                Price = 1.15m,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            if (!context.Products.Any())
            {
                context.Products.Add(breadEntity);
                context.Products.Add(butterEntity);
                context.Products.Add(milkEntity);
            }

            // discount rules
            var breadDiscountRuleEntity = new Entities.DiscountRule
            {
                Id = Guid.NewGuid(),
                Product = butterEntity,
                DiscountProduct = breadEntity,
                Quantity = 2,
                Percentage = 50m,
                Name = "Bread discount",
                Slug = "bread-discount",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            var milkDiscountRuleEntity = new Entities.DiscountRule
            {
                Id = Guid.NewGuid(),
                Product = milkEntity,
                DiscountProduct = milkEntity,
                Quantity = 3,
                Percentage = 100m,
                Name = "Milk discount",
                Slug = "milk-discount",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            if (!context.DiscountRules.Any())
            {
                context.DiscountRules.Add(breadDiscountRuleEntity);
                context.DiscountRules.Add(milkDiscountRuleEntity);
            }

            //basket

            //test basket
            var basketEntity = new Entities.Basket
            {
                Id = Guid.NewGuid(),
                DiscountRules = new List<Entities.DiscountRule>
                {
                    breadDiscountRuleEntity,
                    milkDiscountRuleEntity
                },
                Items = new List<Entities.BasketItem>(),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                User = testUser,
                UserId = testUser.Id
            };

            if (!context.Baskets.Any())
            {
                context.Baskets.Add(basketEntity);
            }

            //basket items
            //last test case basket
            var basketItem1Entity = new Entities.BasketItem
            {
                Id = Guid.NewGuid(),
                Basket = basketEntity,
                BasketId = basketEntity.Id,
                Product = breadEntity,
                Quantity = 1,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            var basketItem2Entity = new Entities.BasketItem
            {
                Id = Guid.NewGuid(),
                Basket = basketEntity,
                BasketId = basketEntity.Id,
                Product = butterEntity,
                Quantity = 2,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            var basketItem3Entity = new Entities.BasketItem
            {
                Id = Guid.NewGuid(),
                Basket = basketEntity,
                BasketId = basketEntity.Id,
                Product = milkEntity,
                Quantity = 8,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            if (!context.BasketItems.Any())
            {
                 context.BasketItems.Add(basketItem1Entity);
                 context.BasketItems.Add(basketItem2Entity);
                 context.BasketItems.Add(basketItem3Entity);
            }

            bool success = context.SaveChanges() > 0;
        }
    }
}
