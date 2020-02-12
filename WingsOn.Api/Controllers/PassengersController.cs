﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Application.Bookings.Resources;
using WingsOn.Application.Shared.Enums;

namespace WingsOn.Api.Controllers
{
    [Produces("application/json")]
    [Route("search/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        /// <summary>
        /// Get list of passengers in specified flight.
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <param name="departureDay"></param>
        /// <returns></returns>
        /// <response code="200">The query is executed successfully.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="404">There is no flight with given id.</response>
        [HttpGet("by-flight/{flightNumber}/{departureDay}")]
        [ProducesResponseType(typeof(PassengerResource), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPassengersInSpecificFlight(string flightNumber, DateTime departureDay)
        {
            return Ok();
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
            return Ok();
        }
    }
}