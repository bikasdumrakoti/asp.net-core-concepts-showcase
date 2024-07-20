using MediatorAndCQRSPatternWithMediatR.Core;
using MediatorAndCQRSPatternWithMediatR.Core.Domain.RepositoryContracts;
using MediatorAndCQRSPatternWithMediatR.Infrastructure.DatabaseContext;
using MediatorAndCQRSPatternWithMediatR.Infrastructure.DbInitializer;
using MediatorAndCQRSPatternWithMediatR.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MediatorAndCQRSPatternWithMediatR.API.Extensions
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDbInitializer, DbInitializer>();

            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(MediatREntryPoint).Assembly);
            });

            return services;
        }
    }
}
