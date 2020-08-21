//   -----------------------------------------------------------------------
//   <copyright file=BetAppService.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 16:49</Date>
//   <Update> 2020-08-20 - 16:49</Update>
//   -----------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Application.Definition;
using Core.DataTransferObject;
using Core.Entities;
using Core.GlobalRepository;

namespace Application.Implementation
{
    public class BetAppService : IBetAppService
    {

        private readonly IRouletteRepository _rouletteRepository;
        private readonly IBetRepository _betRepository;

        public BetAppService(IRouletteRepository rouletteRepository, IBetRepository betRepository)
        {
            _rouletteRepository = rouletteRepository;
            _betRepository = betRepository;
        }

        public async Task<GetAllBetResult> GetAll()
        {
            var r = new GetAllBetResult();
            var data = await _betRepository.GetAllBets();
            r.Data = data;
            return r;
        }

      

        public async Task<CreateBetResult> RegisterBet(Bet bet)
        {
            CreateBetResult result = new CreateBetResult();

            var roulette = await _rouletteRepository.GetRoulette(new Roulette
            {
                Id = bet.RouletteId
            });
            if (roulette == null)
            {
                result.Success = false;
                result.Message = "Roulette not found";
                return result;
            }

            if (!roulette.Open)
            {
                result.Success = false;
                result.Message = "Roulette not Open,Please First Open the Roulette";
                return result;
            }

            await _betRepository.AddBet(bet);
            result.Success = true;
            return result;

        }

        public CreateRouletteResult CloseBet(long rouletteId)
        {
            throw new NotImplementedException();
        }
    }
}