using Microsoft.Extensions.DependencyInjection;

namespace FCG.IoC;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddDependencies()
        {
            services.AddDomain();
            services.AddApplication();
            services.AddInfrastructure();
            
            return services;
        }
    }
}