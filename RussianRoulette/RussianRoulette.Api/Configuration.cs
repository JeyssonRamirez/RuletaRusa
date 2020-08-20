//   -----------------------------------------------------------------------
//   <copyright file=Configuration.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 15:52</Date>
//   <Update> 2020-08-20 - 15:52</Update>
//   -----------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace RussianRoulette.Api
{
    public static partial class Configuration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services


                .AddMvcCore()
                .AddApiExplorer()
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.Converters.Add(new StringEnumConverter());
                    o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .Services
                .AddCors(o => o.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }))
                .AddResponseCompression(options =>
                {
                    options.EnableForHttps = true;
                    options.MimeTypes = new[] { "text/plain", "application/json" };
                });

        }

        public static IApplicationBuilder Configure(IApplicationBuilder app, Func<IApplicationBuilder, IApplicationBuilder> configureHost) => configureHost(app)
            .UseMvc(routes =>
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"));
    }
}