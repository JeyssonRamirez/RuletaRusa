//   -----------------------------------------------------------------------
//   <copyright file=BetController.cs company="Jeysson Ramirez">
//       Copyright (c) Jeysson Ramirez Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2020 -08-20  - 16:50</Date>
//   <Update> 2020-08-20 - 16:50</Update>
//   -----------------------------------------------------------------------

using System;
using System.Net;
using System.Threading.Tasks;
using Application.Definition;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RussianRoulette.Api.Model;
using RussianRoulette.Api.Model.Bet;

namespace RussianRoulette.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BetController : CommonController
    {
        private readonly ILogger<RouletteController> _logger;
        private readonly IBetAppService _betAppService;

        public BetController(ILogger<RouletteController> logger, IBetAppService betAppService)
        {
            _logger = logger;
            _betAppService = betAppService;
        }

        /// <summary>
        /// Register Roulette
        /// </summary> 
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(HttpStatusCode), 200)]
        [ProducesResponseType(400, Type = typeof(ApiBadResponse))]
        public async Task<IActionResult> MakeBet([FromBody] MakeBetModel model, [FromHeader] long userId)
        {

            var result = new BaseApiResponse();
            try
            {

                ValidateModel(model, result);
                if (result.Code == (int)HttpStatusCode.BadRequest)
                {
                    return BadRequest(result);
                }


                var appResult = _betAppService.RegisterBet(new Bet
                {

                    Color = model.Color,
                    Amount = model.Amount,
                    Number = model.Number,
                    UserId = userId
                });
                if (appResult.Success)
                {
                    return Ok(appResult.Data);
                }

                return BadRequest(appResult);

                //return Ok(result);

            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    new BaseApiResponse
                    { Code = 500, Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message });
            }
        }
    }
}