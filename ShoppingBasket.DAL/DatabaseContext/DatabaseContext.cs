using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShoppingBasket.DAL.Entities;

namespace ShoppingBasket.DAL.DBContext
{
    /// <summary>
    /// Database EF context.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        /// <value>
        /// The products.
        /// </value>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the baskets.
        /// </summary>
        /// <value>
        /// The baskets.
        /// </value>
        public DbSet<Basket> Baskets { get; set; }

        /// <summary>
        /// Gets or sets the basket items.
        /// </summary>
        /// <value>
        /// The basket items.
        /// </value>
        public DbSet<BasketItem> BasketItems { get; set; }

        /// <summary>
        /// Gets or sets the discount rules.
        /// </summary>
        /// <value>
        /// The discount rules.
        /// </value>
        public DbSet<DiscountRule> DiscountRules { get; set; }
    }
}
