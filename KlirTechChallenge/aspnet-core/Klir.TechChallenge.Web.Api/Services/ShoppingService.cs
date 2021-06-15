using Klir.TechChallenge.Web.Api.Data.Contracts;
using KlirTechChallenge.Web.Api.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Services
{
    public class ShoppingService: IShoppingService
    {
        private readonly IShoppingRepository _shoppingRepository;
        public ShoppingService(IShoppingRepository shoppingRepository)
        {
            _shoppingRepository = shoppingRepository;
        }

        public async Task<List<Product>> ListAllProducts()
        {
            return await _shoppingRepository.GetAllProducts();
        }
    }
}
