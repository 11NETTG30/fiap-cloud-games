using FCG.Application.Identidade.UseCases;
using FCG.Domain.Identidade.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FCG.IoC;

public static class DomainDI
{
    extension(IServiceCollection services)
    {
        internal IServiceCollection AddDomain()
        {
            services.AddScoped<RefreshTokenDomainService>();
            
            return services;
        }
    }
}