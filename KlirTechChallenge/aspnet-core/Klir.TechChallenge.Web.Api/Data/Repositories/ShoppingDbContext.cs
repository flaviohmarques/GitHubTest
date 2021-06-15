using Klir.TechChallenge.Web.Api.Data.Contracts;
using KlirTechChallenge.Web.Api.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Klir.TechChallenge.Web.Api.Data.Repositories
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options)
       : base(options) { }

        public DbSet<Product> Products { get; set; }

       

    }
}
