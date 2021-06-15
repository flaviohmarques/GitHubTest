using Klir.TechChallenge.Web.Api.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Klir.TechChallenge.Web.Api.Data.Contracts;
using Klir.TechChallenge.Web.Api.Services;
using Microsoft.OpenApi.Models;

namespace KlirTechChallenge.Web.Api
{
    public class Startup
    {
        readonly string AllowSpecificOrigins = "_allowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShoppingDbContext>(options => options.UseInMemoryDatabase(databaseName: "Shopping"));
            services.AddScoped<IShoppingRepository, ShoppingRepository>();
            services.AddScoped<IShoppingService, ShoppingService>();


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "TechChallenge", Version = "v1" });

            });


            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200");
                                  });
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechChallenge WebApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

