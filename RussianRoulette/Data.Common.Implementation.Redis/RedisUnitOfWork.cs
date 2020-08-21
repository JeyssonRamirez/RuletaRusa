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
using BeetleX.Redis;
using Core.DataTransferObject;
using Core.Entities;
using Crosscutting.Util;
using Data.Common.Definition;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Data.Common.Implementation.Redis
{
    public class RedisUnitOfWork : RedisCacheManager, IUnitOfWork
    {
        public object Mapper(object entity, object entity2)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (entity2 == null) throw new ArgumentNullException(nameof(entity2));
            foreach (var propertyInfo in entity.GetType().GetProperties())
            {
                var name = propertyInfo.Name;
                var value = propertyInfo.GetValue(entity, null);
                entity2.GetType().GetProperty(name).SetValue(entity2, value, null);
            }
            return entity2;
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

        public async Task<bool> AddEntity<T>(T item) where T : Entity
        {
            Add($"{item.GetType().Name}[{item.Id.ToString()}]",item,3600);
            return IsAdd($"{item.GetType().Name}[{item.Id.ToString()}]");

            //await Bd.Set(item.GetType().Name, list);
            //return item;
        }

        public async Task<bool> RemoveEntity<T>(T item) where T : Entity
        {
            return Remove($"{item.GetType().Name}[{item.Id.ToString()}]");
        }

        public async Task<T> GetOne<T>(T item) where T : Entity
        {
            return Get<T>($"{item.GetType().Name}[{item.Id.ToString()}]");
        }

        public async Task<int> ExecuteQuery(string query, List<ParameterDto> parameters, bool procedure)
        {
            return 0;
        }

        public RedisUnitOfWork(IOptions<GeneralOptions> options) : base(options)
        {
        }
    }
}