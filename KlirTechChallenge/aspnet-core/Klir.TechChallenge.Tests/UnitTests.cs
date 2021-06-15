using Klir.TechChallenge.Web.Api.Data.Contracts;
using KlirTechChallenge.Web.Api;
using KlirTechChallenge.Web.Api.Data.Models;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KlirTechChallenge.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly IServiceProvider _services =
        Program.CreateHostBuilder(Array.Empty<string>()).Build().Services;


        [Test]
        public void CheckShoppingService()
        {
            var shoppingService = _services.GetRequiredService<IShoppingService>();
            Assert.IsNotNull(shoppingService);
        }

        [Test]
        public async Task IsAnListOfProductsAsync()
        {
            var shoppingService = _services.GetRequiredService<IShoppingService>();
            List<Product> listProducts = await shoppingService.ListAllProducts();
            Assert.IsInstanceOf(listProducts.GetType(), listProducts);
            Assert.IsEmpty(listProducts);
        }

    }
}
