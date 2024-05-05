using System.Collections.Generic;
using FlightLogNet.Models;

namespace FlightLogNet.Controllers
{
    using Facades;
    using Microsoft.AspNetCore.Cors;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [EnableCors]
    [Route("[controller]")]
    public class AirplaneController(
        ILogger<AirplaneController> logger,
        AirplaneFacade airplaneFacade)
        : ControllerBase
    {
        [HttpGet]
        public IEnumerable<AirplaneModel> Get()
        {
            logger.LogDebug("Get airplanes.");
            return airplaneFacade.GetClubAirplanes();
        }

    }
}
