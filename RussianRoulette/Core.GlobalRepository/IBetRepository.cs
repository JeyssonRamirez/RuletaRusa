//   -----------------------------------------------------------------------
//   <copyright file=IBetRepository.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 17:41</Date>
//   <Update> 2020-08-20 - 17:41</Update>
//   -----------------------------------------------------------------------

using System.Threading.Tasks;
using Core.Entities;

namespace Core.GlobalRepository
{
    public interface IBetRepository
    {
        Task<Bet> AddBet(Bet data);
        Task<Bet> GetBet(Bet data);
    }
}