//   -----------------------------------------------------------------------
//   <copyright file=BaseApiResponse.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 14:39</Date>
//   <Update> 2020-08-20 - 14:39</Update>
//   -----------------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Mvc;

namespace RussianRoulette.Api.Model
{
    public class BaseApiResponse
    {

        public int Code { get; set; }
        public string Message { get; set; }

    }
}