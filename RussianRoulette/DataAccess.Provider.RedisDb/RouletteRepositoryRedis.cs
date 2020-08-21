//   ------- ----------------------------------------------------------------
//   <copyright file=RouletteRepositoryRedis.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 17:43</Date>
//   <Update> 2020-08-20 - 17:43</Update>
//   -----------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.GlobalRepository;
using Crosscutting.Util;
using Data.Common.Implementation.Redis;
using Microsoft.Extensions.Options;

namespace DataAccess.Provider.RedisDb
{


    public class RouletteRepositoryRedis : RedisUnitOfWork, IRouletteRepository
    {
       

        public RouletteRepositoryRedis(IOptions<GeneralOptions> options) : base(options)
        {
        }

        public async Task<Roulette> AddRoulette(Roulette data)
        {
           return await this.AddEntity(data);
        }

        public async Task<Roulette> GetRoulette(Roulette data)
        {
            var r=await GetOne<Roulette>(data);
            return r;
        }

        public async Task<Roulette> UpdateRoulette(Roulette data)
        {
            var r = await GetOne(data);
            r.Color = data.Color;
            r.Open = data.Open;
            r.Open = data.Open;
            return await this.AddEntity(data);
            
        }
    }
}