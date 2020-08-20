//   -----------------------------------------------------------------------
//   <copyright file=OpenRouletteModel.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 17:07</Date>
//   <Update> 2020-08-20 - 17:07</Update>
//   -----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace RussianRoulette.Api.Model
{
    public class OpenRouletteModel
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Id { get; set; }
    }
}