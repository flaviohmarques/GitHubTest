using KlirTechChallenge.Web.Api.Data.Models;
using System.Collections.Generic;

namespace Klir.TechChallenge.Web.Api.Data.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public double Total { get; set; }
    }

    public class ShoppingCartItem
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }
        public PromotionType Promotion { get; set; }
        public string PromotionApplied { get; set; }
    }
}
