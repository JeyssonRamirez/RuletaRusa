using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RussianRoulette.Api.Model;

namespace RussianRoulette.Api.Controllers
{



    [ApiController]
    [Route("[controller]")]
    public class RouletteController : ControllerBase
    {


        private readonly ILogger<RouletteController> _logger;

        public RouletteController(ILogger<RouletteController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(HttpStatusCode), 200)]
        [ProducesResponseType(400, Type = typeof(ApiBadResponse))]
        public IEnumerable<Roulette> Get()
        {
            return new List<Roulette>();
        }

        [HttpPost]
        [ProducesResponseType(typeof(HttpStatusCode), 200)]
        [ProducesResponseType(400, Type = typeof(ApiBadResponse))]
        public int Post()
        {
            var rng = new Random();
            return rng.Next(-20, 55);
        }
    }
}
