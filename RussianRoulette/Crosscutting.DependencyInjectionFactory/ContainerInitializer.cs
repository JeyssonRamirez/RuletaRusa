//   -----------------------------------------------------------------------
//   <copyright file=ContainerInitializer.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 11:55</Date>
//   <Update> 2020-08-20 - 11:55</Update>
//   -----------------------------------------------------------------------

using Application.Definition;
using Application.Implementation;
using Microsoft.Extensions.DependencyInjection;
using Unity;

namespace Crosscutting.DependencyInjectionFactory
{
    public static class ContainerInitializer
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            
            #region Croscutting

            #endregion

            #region injection Data Access

            #endregion

            #region Services
            services.AddScoped<IRussianRouletteAppService, RussianRouletteAppService>();
            services.AddScoped<IBetAppService, BetAppService>();
            #endregion

            return services;
        }

        public static void InitializeContainer(this IUnityContainer container)
        {


            //External Repositories 
            //container.RegisterType<ICurrencySource, CurrencySourceHerokuApp>();
            //Mongo

            //Other

            //AppServices
            //container.RegisterType<ITransactionAppService, TransactionAppService>();
            //container.RegisterType<IRateAppService, RateAppService>();

            
        }
    }
}