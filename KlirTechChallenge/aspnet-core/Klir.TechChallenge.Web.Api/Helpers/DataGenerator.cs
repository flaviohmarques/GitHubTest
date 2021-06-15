using Klir.TechChallenge.Web.Api.Data.Repositories;
using KlirTechChallenge.Web.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Klir.TechChallenge.Web.Api.Helpers
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ShoppingDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ShoppingDbContext>>());
            // Look for any board games.
            if (context.Products.Any())
            {
                return;   // Data was already seeded
            }

            context.Products.AddRange(
                new Product
                {
                    Id = 1,
                    Name = "Product A",
                    Price = 20,
                    Promotion = "Buy 1 Get 1 Free",
                    PromotionType = PromotionType.BuyOneGetOneFree
                },
                new Product
                {
                    Id = 2,
                    Name = "Product B",
                    Price = 4,
                    Promotion = "3 for 10 Euro",
                    PromotionType = PromotionType.TreeForTenEuro
                },
                new Product
                {
                    Id = 3,
                    Name = "Product C",
                    Price = 2,
                    Promotion = "",
                    PromotionType = PromotionType.None
                },
               new Product
               {
                   Id = 4,
                   Name = "Product D",
                   Price = 4,
                   Promotion = "3 for 10 Euro",
                   PromotionType = PromotionType.TreeForTenEuro
               });

            context.SaveChanges();
        }
    }
}

