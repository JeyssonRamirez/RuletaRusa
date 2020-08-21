using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Definition;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RussianRoulette.Api.Model;

namespace RussianRoulette.Api.Controllers
{
    /// <summary>
    /// Roulette
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RouletteController : CommonController
    {


        private readonly ILogger<RouletteController> _logger;
        private readonly IRussianRouletteAppService _rouletteAppService;
        public RouletteController(ILogger<RouletteController> logger, IRussianRouletteAppService rouletteAppService)
        {
            _logger = logger;
            _rouletteAppService = rouletteAppService;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(HttpStatusCode), 200)]
        [ProducesResponseType(400, Type = typeof(ApiBadResponse))]
        public async Task<IActionResult> Get()
        {
            var appResult = await _rouletteAppService.GetAll();
            if (appResult.Success)
            {
                return Ok(appResult.Data);
            }

            return BadRequest(appResult);
        }

        /// <summary>
        /// Register Roulette
        /// </summary> 
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[Route("api/[controller]/Register")]
        [ProducesResponseType(typeof(HttpStatusCode), 200)]
        [ProducesResponseType(400, Type = typeof(ApiBadResponse))]
        public async Task<IActionResult> Post([FromBody] RegisterRouletteModel model)
        {

            var result = new BaseApiResponse();
            try
            {

                ValidateModel(model, result);
                if (result.Code == (int)HttpStatusCode.BadRequest)
                {
                    return BadRequest(result);
                }
                var appResult = await _rouletteAppService.CreateRoulette(new Roulette
                {

                });
                if (appResult.Success)
                {
                    return Ok(appResult.Data);
                }

                return BadRequest(appResult);

            }
            catch (Exception ex)
            {
                return StatusCode(500,
                    new BaseApiResponse
                    { Code = 500, Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message });
            }
        }


        /// <summary>
        /// Open Roulette
        /// </summary> 
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/Open")]
        [ProducesResponseType(typeof(HttpStatusCode), 200)]
        [ProducesResponseType(400, Type = typeof(ApiBadResponse))]
        public async Task<IActionResult> OpenRoulette([FromBody] OpenRouletteModel model)
        {

            var result = new BaseApiResponse();
            try
            {

                ValidateModel(model, result);
                if (result.Code == (int)HttpStatusCode.BadRequest)
                {
                    return BadRequest(result);
                }


                var appResult = await _rouletteAppService.OpenRoulette(model.Id);
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

        [HttpDelete]
        [ProducesResponseType(typeof(HttpStatusCode), 200)]
        [ProducesResponseType(400, Type = typeof(ApiBadResponse))]
        public async Task<IActionResult> DeleteRoulette([FromQuery] Guid id)
        {

            var result = new BaseApiResponse();
            try
            {

                var appResult = await _rouletteAppService.DeleteRoulette(id);
                if (appResult.Success)
                {
                    return Ok(appResult);
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
