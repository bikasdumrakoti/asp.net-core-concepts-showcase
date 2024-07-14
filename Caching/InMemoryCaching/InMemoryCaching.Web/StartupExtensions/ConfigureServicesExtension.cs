using InMemoryCaching.DataAccess.DatabaseContext;
using InMemoryCaching.DataAccess.DbInitializer;
using InMemoryCaching.DataAccess.Repositories;
using InMemoryCaching.RepositoryContracts;
using InMemoryCaching.ServiceContracts.ServiceContracts;
using InMemoryCaching.Services;
using Microsoft.EntityFrameworkCore;

namespace InMemoryCaching.Web.StartupExtensions
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IEmployeeGetterAllService, EmployeeGetterAllService>();

            services.AddScoped<IDbInitializer, DbInitializer>();

            return services;
        }
    }
}
