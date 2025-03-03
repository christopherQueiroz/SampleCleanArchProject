using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleCleanArchProject.Application.Interfaces;
using SampleCleanArchProject.Application.Mappings;
using SampleCleanArchProject.Application.Services;
using SampleCleanArchProject.Domain.Interfaces;
using SampleCleanArchProject.Infra.Data.Context;
using SampleCleanArchProject.Infra.Data.Repositories;

namespace SampleCleanArchProject.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile).Assembly);

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext)
                .Assembly.FullName)));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}