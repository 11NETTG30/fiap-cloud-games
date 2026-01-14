using FCG.API.Configurations;
using FCG.API.Middlewares;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddLoggingConfiguration();
builder.Services.AddControllers();
builder.Services.AddDocumentation();
builder.Services.AddProblemDetailsConfiguration();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDocumentation();
}

app.UseGlobalExceptionMiddleware();
app.UseDomainExceptionMiddleware();
app.UseStatusCodePages();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();