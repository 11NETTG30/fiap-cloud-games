using FCG.Application.Identidade.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace FCG.IoC;

public static class ApplicationDI
{
    extension(IServiceCollection services)
    {
        internal IServiceCollection AddApplication()
        {
            services.AddScoped<LoginUseCase>();
            services.AddScoped<LogoutUseCase>();
            services.AddScoped<RefreshTokenUseCase>();
            
            return services;
        }
    }
}