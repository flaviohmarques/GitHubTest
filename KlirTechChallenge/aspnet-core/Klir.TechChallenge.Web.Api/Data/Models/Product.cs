using System;

namespace KlirTechChallenge.Web.Api.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Promotion { get; set; }
        public PromotionType PromotionType { get; set; }
    }
}
