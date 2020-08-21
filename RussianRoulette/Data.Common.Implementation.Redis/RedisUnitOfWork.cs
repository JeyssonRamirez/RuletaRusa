//   -----------------------------------------------------------------------
//   <copyright file=RedisUnitOfWork.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 18:36</Date>
//   <Update> 2020-08-20 - 18:36</Update>
//   -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataTransferObject;
using Core.Entities;
using Crosscutting.Util;
using Data.Common.Definition;
using Microsoft.Extensions.Options;

namespace Data.Common.Implementation.Redis
{
    public class RedisUnitOfWork : ContextRedis, IUnitOfWork
    {
        public RedisUnitOfWork(IOptions<GeneralOptions> options) : base(options)
        {
        }

        public async Task<int> CommitInt()
        {
            throw new NotImplementedException();
        }

        public async Task RollbackChanges()
        {
            throw new NotImplementedException();
        }

        public async Task AttachEntity<T>(T item) where T : Entity
        {
            throw new NotImplementedException();
        }

        public async Task<T> AddEntity<T>(T item) where T : Entity
        {
            await BeetleX.Redis.Redis.Set($"{item.GetType().Name}[{item.Id.ToString()}]", item);
            return item;
        }

        public async Task<bool> RemoveEntity<T>(T item) where T : Entity
        {
            var totalDel= await BeetleX.Redis.Redis.Del($"{item.GetType().Name}[{item.Id.ToString()}]");
            return totalDel>0;
        }

        public async Task<T> GetOne<T>(T item) where T : Entity
        {
            var key = await BeetleX.Redis.Redis.Get<T>($"{item.GetType().Name}[{item.Id.ToString()}]");
            return key;
        }

        public async Task<int> ExecuteQuery(string query, List<ParameterDto> parameters, bool procedure)
        {
            return 0;
        }
    }
}