using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ShoppingBasket.API.Controllers;
using ShoppingBasket.Model;
using ShoppingBasket.Model.Common;
using ShoppingBasket.Repository.Common;
using ShoppingBasket.Service;
using ShoppingBasket.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBasket.Tests
{
    /// <summary>
    /// Basket service tests.
    /// </summary>
    public class BasketServiceTest
    {
        /// <summary>
        /// The basket
        /// </summary>
        private Mock<IBasket> basket;

        /// <summary>
        /// The bread
        /// </summary>
        private Mock<IProduct> bread;
        /// <summary>
        /// The butter
        /// </summary>
        private Mock<IProduct> butter;
        /// <summary>
        /// The milk
        /// </summary>
        private Mock<IProduct> milk;

        /// <summary>
        /// The bread discount rule
        /// </summary>
        private Mock<IDiscountRule> breadDiscountRule;
        /// <summary>
        /// The milk discount rule
        /// </summary>
        private Mock<IDiscountRule> milkDiscountRule;
        /// <summary>
        /// The mapper
        /// </summary>
        private Mock<IMapper> mapper;
        /// <summary>
        /// The basket service logger mock
        /// </summary>
        private Mock<ILogger<BasketService>> basketServiceLoggerMock;
        /// <summary>
        /// The discount service mock
        /// </summary>
        private Mock<IDiscountService> discountServiceMock;
        /// <summary>
        /// The product service mock
        /// </summary>
        private Mock<IProductService> productServiceMock;
        /// <summary>
        /// The basket repository mock
        /// </summary>
        private Mock<IBasketRepository> basketRepositoryMock;

        /// <summary>
        /// The basket identifier
        /// </summary>
        private Guid BasketId = Guid.NewGuid();

        /// <summary>
        /// Gets the test cases.
        /// </summary>
        /// <value>
        /// The test cases.
        /// </value>
        public static IEnumerable<object[]> TestCases => new List<object[]>
        {
            new object[] { 1, 1, 1, 2.95m },
            new object[] { 2, 2, 0, 3.10m },
            new object[] { 0, 0, 4, 3.45m },
            new object[] { 1, 2, 8, 9.00m },
        };

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            bread = new Mock<IProduct>();
            bread.SetupAllProperties();

            bread.Setup(x => x.Id == Guid.NewGuid());
            //products
            bread = new Product
            {
                Id = Guid.NewGuid(),
                Name = "bread",
                Slug = "bread",
                Price = 1,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            butter = new Product
            {
                Id = Guid.NewGuid(),
                Name = "butter",
                Slug = "butter",
                Price = 0.8m,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            milk = new Product
            {
                Id = Guid.NewGuid(),
                Name = "milk",
                Slug = "milk",
                Price = 1.15m,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            //discount rules
            breadDiscountRule = new DiscountRule
            {
                Id = Guid.NewGuid(),
                Product = butter,
                DiscountProduct = bread,
                Quantity = 2,
                Percentage = 50m,
                Name = "Bread discount",
                Slug = "bread-discount",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            milkDiscountRule = new DiscountRule
            {
                Id = Guid.NewGuid(),
                Product = milk,
                DiscountProduct = milk,
                Quantity = 3,
                Percentage = 100m,
                Name = "Milk discount",
                Slug = "milk-discount",
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            //basket
            basket = new Basket
            {
                Id = BasketId,
                DiscountRules = new List<IDiscountRule>
                {
                    breadDiscountRule,
                    milkDiscountRule
                },
                Items = new List<IBasketItem>(),
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            };

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ShoppingBasket.API.AutoMapperProfile());
                mc.AddProfile(new ShoppingBasket.Model.AutoMapperProfile());
            });

            mapper = mappingConfig.CreateMapper();

            discountServiceMock = new Mock<IDiscountService>();
            productServiceMock = new Mock<IProductService>();
            basketRepositoryMock = new Mock<IBasketRepository>();
            basketServiceLoggerMock = new Mock<ILogger<BasketService>>();
        }

        /// <summary>
        /// Calculates the shopping basket total returns expected amount.
        /// </summary>
        /// <param name="breadCount">The bread count.</param>
        /// <param name="butterCount">The butter count.</param>
        /// <param name="milkCount">The milk count.</param>
        /// <param name="expectedResult">The expected result.</param>
        [Test]
        [TestCaseSource(nameof(TestCases))]
        public async Task Calculate_Shopping_Basket_Total_Returns_Expected_Amount(int breadCount, int butterCount, int milkCount, decimal expectedResult)
        {
            //bread
            basket.Items.Add(new BasketItem
            {
                Id = Guid.NewGuid(),
                BasketId = BasketId,
                Product = bread,
                Quantity = breadCount,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            });

            //butter
            basket.Items.Add(new BasketItem
            {
                Id = Guid.NewGuid(),
                BasketId = BasketId,
                Product = butter,
                Quantity = butterCount,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            });

            //milk
            basket.Items.Add(new BasketItem
            {
                Id = Guid.NewGuid(),
                BasketId = BasketId,
                Product = milk,
                Quantity = milkCount,
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow
            });

            discountServiceMock.Setup(p => p.ApplyDiscountsAsync(It.IsAny<IBasket>())).Returns(Task.FromResult(expectedResult));

            BasketService basketService = new BasketService(basketRepositoryMock.Object,
                discountServiceMock.Object,
                productServiceMock.Object,
                mapper,
                basketServiceLoggerMock.Object);

            var totalSum = await basketService.GetTotalAsync(BasketId);

            Assert.AreEqual(expectedResult, totalSum);
        }
    }
}