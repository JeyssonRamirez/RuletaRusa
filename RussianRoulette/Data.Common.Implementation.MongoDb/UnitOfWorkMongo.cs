//   -----------------------------------------------------------------------
//   <copyright file=UnitOfWorkMongo.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 12:15</Date>
//   <Update> 2020-08-20 - 12:15</Update>
//   -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataTransferObject;
using Core.Entities;
using Data.Common.Definition;

namespace Data.Common.Implementation.MongoDb
{
    public class UnitOfWorkMongo : IUnitOfWork
    {
        public Task<int> CommitInt()
        {
            throw new System.NotImplementedException();
        }

        public Task RollbackChanges()
        {
            throw new System.NotImplementedException();
        }

        public Task AttachEntity<T>(T item) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> AddEntity<T>(T item) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveEntity<T>(T item) where T : Entity
        {
            throw new System.NotImplementedException();
        }

        public Task<int> ExecuteQuery(string query, List<ParameterDto> parameters, bool procedure)
        {
            throw new System.NotImplementedException();
        }
    }
}