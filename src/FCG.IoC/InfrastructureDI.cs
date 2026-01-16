using FCG.Application.Identidade.Security;
using FCG.Domain.Identidade.Entities;
using FCG.Domain.Identidade.Repositories;
using FCG.Domain.Identidade.Security;
using FCG.Domain.Shared.UoW;
using FCG.Infrastructure.Identidade.Configurations;
using FCG.Infrastructure.Identidade.Persistence.Repositories;
using FCG.Infrastructure.Identidade.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FCG.IoC;

public static class InfrastructureDI
{
    extension(IServiceCollection services)
    {
        internal void AddInfrastructure()
        {
            services.AddRepositories();
            
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ISenhaHasher, Argon2IdSenhaHasher>();
            
            services.AddSingleton<ITokenSettings>(provider =>
            {
                JwtSettings jwtSettings = provider.GetRequiredService<IOptions<JwtSettings>>().Value;
                return jwtSettings;
            });
        }

        private void AddRepositories()
        {
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
        
        
    }
}