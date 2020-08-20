using System;
using Core.DataTransferObject;
using Core.Entities;

namespace Application.Definition
{
    public interface IRussianRouletteAppService
    {
        BaseApiResult GetAll();
        BaseApiResult CreateRoulette(Roulette roulette);
    }
}
