using FCG.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FCG.Infrastructure.Configuration
{
    public static class FcgDbConfiguration
    {
        public static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<FcgDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection")
            ));

            return services;
        }
    }
}
