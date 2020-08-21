//   -----------------------------------------------------------------------
//   <copyright file=MakeBetModel.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 17:07</Date>
//   <Update> 2020-08-20 - 17:07</Update>
//   -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace RussianRoulette.Api.Model.Bet
{
    /// <summary>
    /// Make Bet Model
    /// </summary>
    public class MakeBetModel
    {
        [Required]

        public Guid RouletteId { get; set; }
        [Required]
        [Range(1, 2, ErrorMessage = "The field {0} must be greater than {1}.")]
        public ColorType Color { get; set; }
        [Required]
        [Range(0, 36, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Number { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "The field {0} must be greater than {1} USD.")]
        public decimal Amount { get; set; }

    }

     public class CloseBetsModel
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public long RouletteId { get; set; }

    }
}