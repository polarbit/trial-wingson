using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        /// <returns></returns>
        /// <response code="200">The booking is created and returned.</response>
        /// <response code="400">Bad request. The new booking form is not valid.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="404">There is no flight with given id.</response>
        [HttpPost]
        public async Task<IActionResult> CreateBooking(int flightId, [FromBody]NewBookingForm newBookingForm)
        {
            return Ok();
        }
    }
}