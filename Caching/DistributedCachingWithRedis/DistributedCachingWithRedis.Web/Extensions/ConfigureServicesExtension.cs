using DistributedCachingWithRedis.DataAccess.DatabaseContext;
using DistributedCachingWithRedis.DataAccess.DbInitializer;
using DistributedCachingWithRedis.DataAccess.Repositories;
using DistributedCachingWithRedis.RepositoryContracts;
using DistributedCachingWithRedis.ServiceContracts.ServiceContracts;
using DistributedCachingWithRedis.Services;
using Microsoft.EntityFrameworkCore;

namespace DistributedCachingWithRedis.Web.Extensions
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

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "DCwR_";
            });

            return services;
        }
    }
}
