using Demo.EntityFramework.Models;
using Demo.Repository.Repositories;
using Demo.Service.Interfaces;
using Demo.Service.Services;

namespace Demo.API.Extensions
{
    public static class Servises
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddDbContext<Project5Context>(); 
            services.AddTransient<IRepository<Product>, Repository<Product>>();
            services.AddTransient<IRepository<Category>, Repository<Category>>();
            services.AddTransient<IRepository<User>, Repository<User>>();
            services.AddTransient<IRepository<Userroll>, Repository<Userroll>>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
