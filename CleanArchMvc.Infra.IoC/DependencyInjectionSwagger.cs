using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjectionSwagger
    {
        public static IServiceCollection AddInfrastructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
             {
                 c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "CleanArchMvc.API", Version = "v1" });

                 c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                 {
                     //definir as configurações
                     Name = "Authorization",
                     Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                     Scheme = "Bearer",
                     BearerFormat = "JWT",
                     In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                     Description = "JWT authorization header using the bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then token in the input below. \r\n\r\nExample: \"Bearer 12345abcdef\"",
                 });

                 c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                 {
                     {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                             new string[]{}
                     }
                 });
             });

            return services;
        }
    }
}
