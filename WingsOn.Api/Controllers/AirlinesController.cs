using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Application.Dto.Resources;
using WingsOn.Application.Queries.GetAllAirlines;

namespace WingsOn.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AirlinesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all airlines.
        /// </summary>
        /// <returns></returns>
        /// /// <response code="200">The request is successful</response>
        /// <response code="401">Unauthorized request.</response>
        [HttpGet("")]
        [ProducesResponseType(typeof(AirlineResource[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAirlines()
        {
            var result = await _mediator.Send(new GetAllAirlinesQuery());

            return Ok(result);
        }
    }
}