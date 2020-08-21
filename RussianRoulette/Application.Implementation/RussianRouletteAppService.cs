//   -----------------------------------------------------------------------
//   <copyright file=Class1.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 11:48</Date>
//   <Update> 2020-08-20 - 11:59</Update>
//   -----------------------------------------------------------------------

#region

using System;
using System.Threading.Tasks;
using Application.Definition;
using Core.DataTransferObject;
using Core.Entities;
using Core.GlobalRepository;

#endregion

namespace Application.Implementation
{
    public class RussianRouletteAppService : IRussianRouletteAppService
    {
        private readonly IRouletteRepository _rouletteRepository;

        public RussianRouletteAppService(IRouletteRepository rouletteRepository)
        {
            _rouletteRepository = rouletteRepository;
        }

        public async Task<GetAllRouletteResult> GetAll()
        {
            var r = new GetAllRouletteResult();
            var data = await _rouletteRepository.GetAllRoulette();
            r.Data = data;
            return r;
        }

        public async Task<CreateRouletteResult> CreateRoulette(Roulette roulette)
        {
            roulette.Id = Guid.NewGuid();
            roulette.Open = false;
            roulette.Color = ColorType.NotDefined;
            roulette.Status = StatusType.Inactive;
            roulette.WinnerNumber = -1;
            roulette = await _rouletteRepository.AddRoulette(roulette);



            var result = new CreateRouletteResult();
            result.Data = roulette.Id;
            result.Success = true;

            return result;
        }

        public async Task<OpenRouletteResult> OpenRoulette(Guid rouletteId)
        {
            var current = await _rouletteRepository.GetRoulette(new Roulette { Id = rouletteId });
            current.Open = true;
            current.Status = StatusType.Active;
            current = await _rouletteRepository.UpdateRoulette(current);
            var result = new OpenRouletteResult();
            result.Data = true;
            return result;

        }

        public async Task<DeleteRouletteResult> DeleteRoulette(Guid rouletteId)
        {
            var result = new DeleteRouletteResult();
            result.Data = await _rouletteRepository.DeleteRoulette(rouletteId);
            result.Success = result.Data;
            return result;
        }
    }
}