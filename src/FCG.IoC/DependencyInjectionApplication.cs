using FCG.Application.Identidade.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace FCG.IoC;

public static class DependencyInjectionApplication
{
    extension(IServiceCollection services)
    {
        internal void AddApplication()
        {
            services.AddScoped<CriarUsuarioUseCase>();
            services.AddScoped<LoginUseCase>();
            services.AddScoped<LogoutUseCase>();
            services.AddScoped<RefreshTokenUseCase>();
        }
    }
}