using System;
using Core.DataTransferObject;
using Core.Entities;

namespace Application.Definition
{
    public interface IRussianRouletteAppService
    {
        BaseApiResult GetAll();
        CreateRouletteResult CreateRoulette(Roulette roulette);
        CreateRouletteResult OpenRoulette(long rouletteId);
    }
}
