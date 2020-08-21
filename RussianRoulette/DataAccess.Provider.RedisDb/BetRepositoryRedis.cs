using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.GlobalRepository;
using Crosscutting.Util;
using Data.Common.Implementation.Redis;
using Microsoft.Extensions.Options;

namespace DataAccess.Provider.RedisDb
{
    public class BetRepositoryRedis : RedisUnitOfWork, IBetRepository
    {
        public BetRepositoryRedis(IOptions<GeneralOptions> options) : base(options)
        {
        }
        public async Task<Bet> AddBet(Bet data)
        {
            if (await AddEntity(data))
            {
                return data;
            }

            throw new Exception("Algo paso en el Insercion ");
        }

        public async Task<Bet> GetBet(Bet data)
        {
            var r = await GetOne(data);
            return r;
        }
    }
}
