//   -----------------------------------------------------------------------
//   <copyright file=IUnitOfWork.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 12:12</Date>
//   <Update> 2020-08-20 - 12:12</Update>
//   -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DataTransferObject;
using Core.Entities;

namespace Data.Common.Definition
{
    public interface IUnitOfWork
    {

        Task<int> CommitInt();
        Task RollbackChanges();
        Task AttachEntity<T>(T item) where T : Entity;
        Task<bool> AddEntity<T>(T item) where T : Entity;
        Task<bool> RemoveEntity<T>(T item) where T : Entity;
        Task<int> ExecuteQuery(string query, List<ParameterDto> parameters, bool procedure);
    }
}