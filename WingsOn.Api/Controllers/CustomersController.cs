﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Application.Customers.Commands.UpdateCustomerEmail;
using WingsOn.Application.Customers.Queries.GetAllCustomers;
using WingsOn.Application.Customers.Queries.GetCustomerById;
using WingsOn.Application.Customers.Resources;

namespace WingsOn.Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// List all customers.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">All customers are returned.</response>
        /// <response code="401">Unauthorized request.</response>
        [HttpGet]
        [ProducesResponseType(typeof(CustomerResource[]), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCustomersId()
        {
            var result = await _mediator.Send(new GetAllCustomersQuery());

            return Ok(result);
        }

        /// <summary>
        /// Returns a specific customer by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="200">The customer is found and returned.</response>
        /// <response code="401">Unauthorized request.</response>
        /// <response code="404">There is no customer with given id.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CustomerResource), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var result = await _mediator.Send(new GetCustomerByIdQuery(id));

            return Ok(result);
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
        /// <response code="404">There is no customer with given id.</response>
        [HttpPost("{id}/email")]
        public async Task<IActionResult> UpdateCustomerEmail(int id, [FromForm]string email)
        {
            await _mediator.Send(new UpdateCustomerEmailCommand(id, email));

            return Ok();
        }
    }
}