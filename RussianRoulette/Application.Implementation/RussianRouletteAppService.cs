﻿//   -----------------------------------------------------------------------
//   <copyright file=Class1.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 11:48</Date>
//   <Update> 2020-08-20 - 11:59</Update>
//   -----------------------------------------------------------------------

#region

using System;
using Application.Definition;
using Core.DataTransferObject;
using Core.Entities;

#endregion

namespace Application.Implementation
{
    public class RussianRouletteAppService : IRussianRouletteAppService
    {
        public BaseApiResult GetAll()
        {
            throw new NotImplementedException();
        }

        public CreateRouletteResult CreateRoulette(Roulette roulette)
        {
            var result = new CreateRouletteResult();
            result.Data = 0;
            return result;
        }
    }
}