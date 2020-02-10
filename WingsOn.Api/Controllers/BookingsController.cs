using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Application.Dtos.Forms;
using WingsOn.Api.Application.Dtos.Resources;

namespace WingsOn.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        /// <summary>
        /// Returns a specific booking by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">The booking is found and returned.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="404">There is no booking with given id.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BookingResource), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var result = new List<BookingResource>
            {
                new BookingResource
                {
                    Id = id
                }
            };

            return await Task.FromResult(Ok(result));
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
        public async Task<IActionResult> AddBooking(int flightId, [FromBody]NewBookingForm newBookingForm)
        {
            return Ok();
        }
    }
}