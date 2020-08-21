//   ------- ----------------------------------------------------------------
//   <copyright file=RouletteRepositoryRedis.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 17:43</Date>
//   <Update> 2020-08-20 - 17:43</Update>
//   -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<List<Roulette>> GetAllRoulette()
        {
            var list = new List<Roulette>();
            var rouletteKey = GetKeyList().Where(s => s.Contains("Roulette")).ToList();

            foreach (var key in rouletteKey)
            {
                list.Add(Get<Roulette>(key));
            }

            return Task.FromResult(list);

        }

        public async Task<Roulette> AddRoulette(Roulette data)
        {
            if (await AddEntity(data))
            {
                return data;
            }

            throw new Exception("Algo paso en el Insercion ");
        }

        public async Task<Roulette> GetRoulette(Roulette data)
        {
            var r = await GetOne(data);
            return r;
        }

        public async Task<Roulette> UpdateRoulette(Roulette data)
        {
            var r = await GetOne(data);

            Mapper(data, r);

            if (await DeleteRoulette(data.Id))
            {
                if (await AddEntity(r))
                {
                    return data;
                }
            }
            throw new Exception("Algo paso en el Update");

        }

        public Task<bool> DeleteRoulette(Guid idGuid)
        {
            return RemoveEntity(new Roulette { Id = idGuid });
        }
    }
}