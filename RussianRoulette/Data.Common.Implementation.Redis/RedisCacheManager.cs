//   -----------------------------------------------------------------------
//   <copyright file=RedisCacheManager.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 20:06</Date>
//   <Update> 2020-08-20 - 20:06</Update>
//   -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Crosscutting.Util;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Data.Common.Implementation.Redis
{
    public class RedisCacheManager
    {

        public RedisCacheManager(IOptions<GeneralOptions> options)
        {

            var configurationOptions = new ConfigurationOptions();
            configurationOptions.EndPoints.Add(options.Value.RedisSettings.Server, options.Value.RedisSettings.Port);

            configurationOptions.Password = options.Value.RedisSettings.Password;
            configurationOptions.AllowAdmin = true;
            configurationOptions.AbortOnConnectFail = false;


            Connection = ConnectionMultiplexer.Connect(configurationOptions);
        }


        public ConnectionMultiplexer Connection;

        public IDatabase RedisCache => Connection.GetDatabase();

        public void Add(string key, object data, int cacheTime)
        {
            if (data == null || IsAdd(key))
                return;

            var value = TimeSpan.FromMinutes(cacheTime);

            RedisCache.StringSet(key, Serialize(data), value);
        }

        public T Get<T>(string key)
        {
            var value = RedisCache.StringGet(key);

            if (!value.HasValue)
                return default(T);

            return Deserialize<T>(value);
        }

        public bool IsAdd(string key)
        {
            return RedisCache.KeyExists(key);
        }

        public bool Remove(string key)
        {
           return RedisCache.KeyDelete(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var endPoints = Connection.GetEndPoints();

            foreach (var endpoint in endPoints)
            {
                var server = Connection.GetServer(endpoint);
                var enumerable = server.Keys(RedisCache.Database, pattern);
                foreach (var current in enumerable)
                    Remove(current);
            }
        }

        public void Clear()
        {
            var endPoints = Connection.GetEndPoints();

            foreach (var endpoint in endPoints)
            {
                var server = Connection.GetServer(endpoint);

                var enumerable = server.Keys(RedisCache.Database);

                foreach (var current in enumerable)
                    Remove(current);
            }
        }

        public List<string> GetKeyList()
        {
            var list = new List<string>();

            var endPoints = Connection.GetEndPoints();

            foreach (var endpoint in endPoints)
            {
                var server = Connection.GetServer(endpoint);

                var enumerable = server.Keys(RedisCache.Database);

                foreach (var redisKey in enumerable)
                    list.Add(redisKey);
            }

            return list;
        }

        protected virtual string Serialize(object serializableObject)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return JsonConvert.SerializeObject(serializableObject, jsonSerializerSettings);
        }

        protected virtual T Deserialize<T>(string serializedObject)
        {
            if (serializedObject == null)
                return default(T);

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            return JsonConvert.DeserializeObject<T>(serializedObject, jsonSerializerSettings);
        }
    }
}