//   -----------------------------------------------------------------------
//   <copyright file=ContextRedis.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 18:35</Date>
//   <Update> 2020-08-20 - 18:35</Update>
//   -----------------------------------------------------------------------

using BeetleX.Redis;
using Crosscutting.Util;
using Microsoft.Extensions.Options;

namespace Data.Common.Implementation.Redis
{
    public class ContextRedis 

    {
        public readonly RedisDB Bd;
        public ContextRedis(IOptions<GeneralOptions> options)
        {
            var settings1 = options.Value.RedisSettings;

            Bd = new RedisDB(1);
            Bd.DataFormater = new JsonFormater();
            //_bd.Host.AddWriteHost(settings1.Server);
            //SSL
            Bd.Host.AddWriteHost(settings1.Server, settings1.Port, settings1.Ssl);
            //password 
            Bd.Host.AddWriteHost(settings1.Server).Password = settings1.Password;
        }

    }
}