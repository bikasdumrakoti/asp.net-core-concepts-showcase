namespace DistributedCachingWithRedis.Web.Extensions
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllersWithViews();

            return services;
        }
    }
}
