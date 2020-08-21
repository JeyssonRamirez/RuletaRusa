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
    public class ContextRedis : RedisDB
    {
        private readonly RedisDB _bd; 
        public ContextRedis(IOptions<GeneralOptions> options)
        {
            var settings1 = options.Value.RedisSettings;

            _bd = new RedisDB(1);
            _bd.DataFormater = new JsonFormater();
            //_bd.Host.AddWriteHost(settings1.Server);
            //SSL
            _bd.Host.AddWriteHost(settings1.Server, settings1.Port, settings1.Ssl);
            //password 
            _bd.Host.AddWriteHost(settings1.Server).Password = settings1.Password;
        }

        


    }
}