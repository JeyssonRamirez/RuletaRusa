//   -----------------------------------------------------------------------
//   <copyright file=IBetAppService.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 16:49</Date>
//   <Update> 2020-08-20 - 16:49</Update>
//   -----------------------------------------------------------------------

using System.Threading.Tasks;
using Core.DataTransferObject;
using Core.Entities;

namespace Application.Definition
{
    public interface IBetAppService
    {
        Task<GetAllBetResult> GetAll() ;
        Task<CreateBetResult> RegisterBet(Bet bet);
        CreateRouletteResult CloseBet(long rouletteId);
    }
}