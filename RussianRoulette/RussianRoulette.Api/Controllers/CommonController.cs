//   -----------------------------------------------------------------------
//   <copyright file=CommonController.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 15:18</Date>
//   <Update> 2020-08-20 - 15:18</Update>
//   -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RussianRoulette.Api.Model;

namespace RussianRoulette.Api.Controllers
{
    /// <summary>
    /// base Controller
    /// </summary>
    public class CommonController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        protected BaseApiResponse ValidateModel(Object model , BaseApiResponse response)
        {
            TryValidateModel(model);
            if (!ModelState.IsValid)
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();

                if (allErrors.Any())
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = string.Join(", ", allErrors.Select(f => f.ErrorMessage).ToArray());
                    
                    return response;
                }
            }

            return response;
        }
    }
}