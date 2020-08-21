//   -----------------------------------------------------------------------
//   <copyright file=MongoDataContext.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 12:18</Date>
//   <Update> 2020-08-20 - 12:18</Update>
//   -----------------------------------------------------------------------

using System.Configuration;
using Core.Entities;
using Data.Common.Definition;
using MongoDB.Driver;

namespace Data.Common.Implementation.MongoDb
{
    public class MongoDataContext : UnitOfWorkMongo, IUnitOfWork
    {
        private readonly MongoClient _client;

        private readonly string _mongoDbName;
        private readonly string _mongoServerUrl;

        //private readonly IConfiguration _config;
        public MongoDataContext()
        {
            _mongoServerUrl = ConfigurationManager.ConnectionStrings["DBCrawler"].ConnectionString;
            _mongoDbName = ConfigurationManager.AppSettings["DBName"].ToString();
            _client = new MongoClient(_mongoServerUrl);
        }

        public MongoDatabase GetDatabase()
        {
            return _client.GetServer().GetDatabase(_mongoDbName);
        }

        public void DropDatabase(string dbName)
        {
            var server = _client.GetServer();
            server.DropDatabase(dbName);
        }

        public void DropCollection<T>() where T : Entity
        {
            var database = GetDatabase();
            var collectionName = typeof(T).Name.ToLower();

            if (database.CollectionExists(collectionName))
            {
                database.DropCollection(collectionName);
            }
        }
    }
}