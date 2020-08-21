//   -----------------------------------------------------------------------
//   <copyright file=CreateRouletteResult.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 20:48</Date>
//   <Update> 2020-08-20 - 20:48</Update>
//   -----------------------------------------------------------------------

using System;

namespace Core.DataTransferObject
{
    public class CreateRouletteResult: BaseApiResult
    {
        public new Guid Data { set; get; }
    }

    public class CreateBetResult : BaseApiResult
    {
        public new Guid Data { set; get; }
    }
}