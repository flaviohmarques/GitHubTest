using KlirTechChallenge.Web.Api.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Data.Contracts
{
    public interface IShoppingService
    {
        Task<List<Product>> ListAllProducts();
    }
}
