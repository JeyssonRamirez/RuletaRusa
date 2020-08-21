//   -----------------------------------------------------------------------
//   <copyright file=GetAllBetResult.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 21:36</Date>
//   <Update> 2020-08-20 - 21:36</Update>
//   -----------------------------------------------------------------------

using System.Collections.Generic;
using Core.Entities;

namespace Core.DataTransferObject
{
    public class GetAllBetResult : BaseApiResult
    {

        public new List<Bet> Data { set; get; }
    }
}