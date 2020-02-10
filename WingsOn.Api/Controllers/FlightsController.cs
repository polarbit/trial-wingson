using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Application.Dto.Resources;

namespace WingsOn.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        /// <summary>
        /// Returns a specific flight by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">The flight is found and returned.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="404">There is no flight with given id.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FlightResource), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFlightById(int id)
        {
            var result = new List<FlightResource>
            {
                new FlightResource
                {
                    Id = id
                }
            };

            return await Task.FromResult(Ok(result));
        }

        /// <summary>
        /// Get a list of flights; optinally applying some filters and sorting.
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <param name="departureDay"></param>
        /// <returns></returns>
        /// /// <response code="200">The flight is found and returned.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="404">There is no flight with given flight number and departure day.</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(FlightResource[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFlights()
        {
            var result = new List<FlightResource>
            {
                new FlightResource
                {
                    Id = 1
                }
            };

            return await Task.FromResult(Ok(result));
        }
    }
}