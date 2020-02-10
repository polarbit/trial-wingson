using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Application.Airports.Queries.GetAllAirports;
using WingsOn.Application.Airports.Resources;

namespace WingsOn.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AirportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all airports.
        /// </summary>
        /// <returns></returns>
        /// /// <response code="200">Request is successful.</response>
        /// <response code="401">Unauthorized request.</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(AirportResource[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAirports()
        {
            var result = await _mediator.Send(new GetAllAirportsQuery());

            return Ok(result);
        }
    }
}