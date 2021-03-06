﻿//   -----------------------------------------------------------------------
//   <copyright file=BaseApiResult.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 11:57</Date>
//   <Update> 2020-08-20 - 11:57</Update>
//   -----------------------------------------------------------------------

using System.Collections.Generic;
using Core.Entities;

namespace Core.DataTransferObject
{
    public class BaseApiResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { set; get; }
    }


    public class ClosedBetResult : BaseApiResult
    {

        public new List<Bet> Data { set; get; }
    }

}