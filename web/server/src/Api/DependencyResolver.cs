using Api.Mapping;
using Api.Middleware;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Api;

public static class DependencyResolver
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddExceptionHandler<ExceptionHandler>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerUI();
        services.AddMapping();

        return services;
    }

    public static IServiceCollection AddSwaggerUI(this IServiceCollection services)
    {
        services.AddSwaggerGen(config =>
        {
            config.SwaggerDoc("v1", new() { Title = "VSCODE_API", Version = "v1" });
            config.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Name = "Authorization",
                Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\""
            });
            config.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        return services;
    }
}