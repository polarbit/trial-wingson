using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WingsOn.Api.Resources
{
    public class PersonResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public PersonGender Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
