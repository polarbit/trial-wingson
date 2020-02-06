using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WingsOn.Api.Resources;

namespace WingsOn.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var result = new List<PersonResource>
            {
                new PersonResource
                {
                    Id = 1,
                    Name = "Safak Ulusoy",
                    Gender = PersonGender.Male,
                    Email = "safak123456@gmaixl.com",
                    DateBirth = DateTime.Today.AddYears(-20),
                    Address = "Kemerkopru Mah. Bartin"
                }
            };

            return Ok(result);
        }
    }
}