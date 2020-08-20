using System;
using System.Threading.Tasks;
using Core.DataTransferObject;
using Core.Entities;

namespace Application.Definition
{
    public interface IRussianRouletteAppService
    {
        BaseApiResult GetAll();
        Task<CreateRouletteResult> CreateRoulette(Roulette roulette);
        Task<OpenRouletteResult> OpenRoulette(Guid rouletteId);
    }
}
