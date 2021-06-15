using Klir.TechChallenge.Web.Api.Data.Contracts;
using KlirTechChallenge.Web.Api.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KlirTechChallenge.Web.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingController : ControllerBase
    {

        private readonly ILogger<ShoppingController> _logger;
        private readonly IShoppingService _shoppingService;

        public ShoppingController(ILogger<ShoppingController> logger, IShoppingService shoppingService)
        {
            _logger = logger;
            _shoppingService = shoppingService;
        }

        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
           return await _shoppingService.ListAllProducts();
        }
    }
}
