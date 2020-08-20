//   -----------------------------------------------------------------------
//   <copyright file=BetAppService.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 16:49</Date>
//   <Update> 2020-08-20 - 16:49</Update>
//   -----------------------------------------------------------------------

using System;
using Application.Definition;
using Core.DataTransferObject;
using Core.Entities;

namespace Application.Implementation
{
    public class BetAppService : IBetAppService
    {
        public BaseApiResult GetAll()
        {
            throw new NotImplementedException();
        }

        public CreateRouletteResult RegisterBet(Bet bet)
        {
            throw new NotImplementedException();
        }

        public CreateRouletteResult CloseBet(long rouletteId)
        {
            throw new NotImplementedException();
        }
    }
}