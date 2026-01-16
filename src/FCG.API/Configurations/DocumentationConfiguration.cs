using Microsoft.OpenApi;
using Scalar.AspNetCore;

namespace FCG.API.Configurations;

public static class DocumentationConfiguration
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddDocumentation()
        {
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Title = "FCG - Plataforma de Jogos",
                        Version = "v1",
                        Description = """
                            API Backend para plataforma de jogos desenvolvida como projeto de pós-graduação em Arquitetura de Sistemas .NET.
                            """,
                        Contact = new OpenApiContact
                        {
                            Name = "11NETTG30",
                            Url = new Uri("https://github.com/11NETTG30/fiap-cloud-games")
                        }
                    };

                    return Task.CompletedTask;
                });
            });
            
            return services;
        }
    }

    extension(WebApplication app)
    {
        public void UseDocumentation()
        {
            app.MapOpenApi();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/openapi/v1.json", "FCG API v1");
                options.DocumentTitle = "FCG - Documentação da API";
                options.DefaultModelsExpandDepth(2);
                options.DisplayRequestDuration();
            });
    
            app.MapScalarApiReference(options =>
            {
                options.Layout = ScalarLayout.Classic;
            });
        }
    }
    
}