using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Application.Bookings.Resources;
using WingsOn.Application.PassengerSearch.Queries.SearchPassengersByFlight;
using WingsOn.Application.PassengerSearch.Queries.SearchPassengersByGender;
using WingsOn.Application.Shared.Enums;

namespace WingsOn.Api.Controllers
{
    [Produces("application/json")]
    [Route("search/passengers")]
    [ApiController]
    public class SearchPassengersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SearchPassengersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get list of passengers in flights with specified flight number.
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <returns></returns>
        /// <response code="200">The query is executed successfully.</response>
        /// <response code="401">Unauthorized request.</response>
        [HttpGet("by-flight/{flightNumber}")]
        [ProducesResponseType(typeof(PassengerResource), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPassengersInSpecificFlight(string flightNumber)
        {
            var result = await _mediator.Send(new SearchPassengersByFlightQuery(flightNumber));

            return Ok(result);
        }

        /// <summary>
        /// Get list of passengers by specified gender.
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        /// <response code="200">The query is executed successfully.</response>
        /// <response code="401">Unauthorized request.</response>
        [HttpGet("by-gender/{gender}")]
        [ProducesResponseType(typeof(PassengerResource), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPassengersByGender(Gender gender)
        {
            var result = await _mediator.Send(new SearchPassengersByGenderQuery(gender));

            return Ok(result);
        }
    }
}