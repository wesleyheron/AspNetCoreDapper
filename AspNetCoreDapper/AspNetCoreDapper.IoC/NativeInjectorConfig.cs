using AspNetCoreDapper.Data.Repositories;
using AspNetCoreDapper.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreDapper.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
