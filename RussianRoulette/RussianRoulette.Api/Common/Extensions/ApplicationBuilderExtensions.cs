//   -----------------------------------------------------------------------
//   <copyright file=ApplicationBuilderExtensions.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 14:46</Date>
//   <Update> 2020-08-20 - 14:46</Update>
//   -----------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace RussianRoulette.Api.Common.Extensions
{
    /// <summary>
    /// ApplicationBuilderExtensions
    /// </summary>
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseCustomOpenAPI(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.ShowExtensions();
                    options.DisplayRequestDuration();
                    options.DocExpansion(DocExpansion.None);
                    options.DocumentTitle = "Roullet API";
                    options.EnableDeepLinking();
                    options.EnableFilter();
                    options.EnableValidator();
                    options.SwaggerEndpoint($"/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });

            return app;
        }


        public static IApplicationBuilder UseOthers(this IApplicationBuilder app)
        {
            app.UseResponseCompression();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseHttpsRedirection();
            return app;
        }

        public static IApplicationBuilder CustomSwagger(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    options.ShowExtensions();
                    options.DisplayRequestDuration();
                    options.DocExpansion(DocExpansion.None);
                    options.DocumentTitle = "Jeysson Ramirez Dev";
                    options.EnableDeepLinking();
                    options.EnableFilter();
                    options.EnableValidator();
                    options.SwaggerEndpoint($"/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });

            return app;
        }
    }
}