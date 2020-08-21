//   -----------------------------------------------------------------------
//   <copyright file=GetAllRouletteResult.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 21:32</Date>
//   <Update> 2020-08-20 - 21:32</Update>
//   -----------------------------------------------------------------------

using System.Collections.Generic;
using Core.Entities;

namespace Core.DataTransferObject
{
    public class GetAllRouletteResult : BaseApiResult
    {

        public new List<Roulette> Data { set; get; }
    }
}