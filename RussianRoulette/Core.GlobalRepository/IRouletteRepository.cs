﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Data.Common.Definition;

namespace Core.GlobalRepository
{
    public interface IRouletteRepository
    {
        Task<List<Roulette>> GetAllRoulette();
        Task<Roulette> AddRoulette(Roulette data);
        Task<Roulette> GetRoulette(Roulette data);
        Task<Roulette> UpdateRoulette(Roulette data);
    }
}
