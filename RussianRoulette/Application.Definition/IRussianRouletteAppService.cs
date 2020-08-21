using System;
using System.Threading.Tasks;
using Core.DataTransferObject;
using Core.Entities;

namespace Application.Definition
{
    public interface IRussianRouletteAppService
    {
        Task<GetAllRouletteResult> GetAll();
        Task<CreateRouletteResult> CreateRoulette(Roulette roulette);
        Task<OpenRouletteResult> OpenRoulette(Guid rouletteId);
        Task<DeleteRouletteResult> DeleteRoulette(Guid rouletteId);
    }
}
