//   -----------------------------------------------------------------------
//   <copyright file=ServiceCollectionExtensions.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 14:25</Date>
//   <Update> 2020-08-20 - 14:25</Update>
//   -----------------------------------------------------------------------

using System;
using System.IO;
using Crosscutting.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace RussianRoulette.Api.Common.Extensions
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GeneralOptions>(configuration.GetSection("GeneralOptions"));
            
            return services;
        }

        /// <summary>
        /// Add Swagger 
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            //Swagger
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme{
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Roullete Api",
                    Description = "Roullete Api Rest",
                    Contact = new OpenApiContact
                    {
                        Name = "Jeysson Ramnirez",
                        Email = "jeysson.ramirez@outlook.com",
                        Url = new Uri("https://www.linkedin.com/in/jsramirezv/")
                    },
                    License = new OpenApiLicense
                    {
                        

                    }
                });
                var xmlFile = $"RussianRoulette.Api.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });


            return services;
        }
        public static IServiceCollection AddModelValidators(this IServiceCollection services)
        {
            //services.AddTransient<IValidator<InputBody<UploadSelfi>>, UploadSelfiValidator>();
            return services;
        }
    }
}