using Klir.TechChallenge.Web.Api.Data.Contracts;
using KlirTechChallenge.Web.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Data.Repositories
{
    public class ShoppingRepository : IShoppingRepository
    {

        private ShoppingDbContext _shoppingDbContext;
        public ShoppingRepository(ShoppingDbContext shoppingDbContext)
        {
            _shoppingDbContext = shoppingDbContext;
        }

        public async Task<List<Product>> GetAllProducts()
        {
           return await _shoppingDbContext.Products.ToListAsync();
        }
    }
}

