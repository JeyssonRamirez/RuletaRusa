//   -----------------------------------------------------------------------
//   <copyright file=CloseBetsModel.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 22:10</Date>
//   <Update> 2020-08-20 - 22:10</Update>
//   -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace RussianRoulette.Api.Model.Bet
{
    /// <summary>
    /// 
    /// </summary>
    public class CloseBetsModel
    {
        [Required]
        public Guid RouletteId { get; set; }

    }
}