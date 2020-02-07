using System;
using WingsOn.Api.Models.Enums;

namespace WingsOn.Api.Models.Resources
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
