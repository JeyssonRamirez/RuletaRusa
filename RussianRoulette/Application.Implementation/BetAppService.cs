//   -----------------------------------------------------------------------
//   <copyright file=BetAppService.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 16:49</Date>
//   <Update> 2020-08-20 - 16:49</Update>
//   -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

        private void UpdateBets(List<Bet> bets, Roulette roulette)
        {
            foreach (var bet in bets.Where(bet => bet.Number == roulette.WinnerNumber && bet.Color == roulette.Color))
            {
                bet.Winner = true;
            }
        }

        private async Task<Roulette> RunRoulette(Roulette roulette)
        {
            roulette.WinnerNumber = new Random().Next(0, 36);
            roulette.Color = (ColorType)new Random().Next(1, 2);
            return await _rouletteRepository.UpdateRoulette(roulette);
        }

        public async Task<ClosedBetResult> CloseBet(Guid rouletteId)
        {
            var result = new ClosedBetResult();
            var roulette = await _rouletteRepository.GetRoulette(new Roulette
            {
                Id = rouletteId
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

            if (roulette.WinnerNumber != -1)
            {
                result.Success = false;
                result.Message = $"Roulette Already Played, the Winner is { roulette.WinnerNumber},With color {roulette.Color}";
                return result;
            }
            await RunRoulette(roulette);


            var bets = await _betRepository.GetAllBetsByRoulette(rouletteId);
            //Change Winners
            UpdateBets(bets, roulette);

            result.Data = bets;
            result.Success = true;

            return result;
        }
    }
}