using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Application.Bookings.Commands.CreateBooking;
using WingsOn.Application.Bookings.Forms;
using WingsOn.Application.Bookings.Queries.GetAllBookings;
using WingsOn.Application.Bookings.Resources;

namespace WingsOn.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Returns all bookings
        /// </summary>
        /// <returns></returns>
        /// <response code="200">All bookings are returned.</response>
        /// <response code="401">Unauthorized request.</response>
        [HttpGet]
        [ProducesResponseType(typeof(BookingResource[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllBookings()
        {
            var result = await _mediator.Send(new GetAllBookingsQuery());

            return Ok(result);
        }

        /// <summary>
        /// Creates a new booking for the specified flight.
        /// </summary>
        /// <param name="flightId"></param>
        /// <param name="newBookingForm"></param>
        /// <returns>Returns the created booking resource.</returns>
        /// <response code="200">The booking is created and returned.</response>
        /// <response code="400">Bad request. The new booking form is not valid.</response>
        /// <response code="401">Unauthorized request.</response>
        [HttpPost]
        [ProducesResponseType(typeof(BookingResource), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateBooking([FromBody]NewBookingForm newBookingForm)
        {
            try
            {
                var result = await _mediator.Send(new CreateBookingCommand(newBookingForm));

                return Ok(result);
            }
            catch (ArgumentException e) when (e.Message.Contains("not found"))
            {
                Console.WriteLine(e);

                return BadRequest($"The resource of parameter {e.ParamName} not found. ({e.Message})");
            }
            catch (ArgumentNullException e)
            {
                return BadRequest($"Missing form parameter: ({e.ParamName})");
            }
            catch (ArgumentException e)
            {
                return BadRequest($"Invalid form parameter: ({e.ParamName}), Msg ({e.Message})");
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}