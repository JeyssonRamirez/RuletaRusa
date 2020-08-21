//   -----------------------------------------------------------------------
//   <copyright file=OpenRouletteModel.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 17:07</Date>
//   <Update> 2020-08-20 - 17:07</Update>
//   -----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace RussianRoulette.Api.Model
{
    public class OpenRouletteModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}