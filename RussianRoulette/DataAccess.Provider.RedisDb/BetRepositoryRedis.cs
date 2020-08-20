using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.GlobalRepository;
using Data.Common.Implementation.Redis;

namespace DataAccess.Provider.RedisDb
{
    public class BetRepositoryRedis : RedisUnitOfWork, IBetRepository
    {
        public BetRepositoryRedis(RedisSettings settings) : base(settings)
        {
        }
        public async Task<Bet> AddRoulette(Bet data)
        {
            return await this.AddEntity(data);
        }

        public async Task<Bet> GetRoulette(Bet data)
        {
            var r = await GetOne(data);
            return r;
        }
    }
}
