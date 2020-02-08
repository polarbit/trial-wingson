using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Models.Enums;
using WingsOn.Api.Models.Resources;

namespace WingsOn.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Returns a specific Person by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">The person is found and returned.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="404">There is no person with given id.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonResource), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var result = new PersonResource
            {
                Id = id,
                Name = "Safak Ulusoy",
                Gender = PersonGender.Male,
                Email = "safak123456@gmaixl.com",
                DateBirth = DateTime.Today.AddYears(-20),
                Address = "Kemerkopru Mah. Bartin"
            };

            return await Task.FromResult(Ok(result));
        }

        /// <summary>
        /// Updates the email address of the customer by id.
        /// </summary>
        /// <remarks>
        /// **Warning:**\
        /// If the person is a customer of an already booked flight; the email address in the  airline system will not be updated.\
        /// Only the email adress in our own bookings database will be updated.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">The email is updated successfully.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="404">There is no person with given id.</response>
        [HttpPost("{id}/email")]
        public async Task<IActionResult> UpdateEmail(int id, string email)
        {
            return await Task.FromResult(Ok());
        }
    }
}