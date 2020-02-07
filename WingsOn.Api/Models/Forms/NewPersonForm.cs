using System;
using WingsOn.Api.Models.Enums;

namespace WingsOn.Api.Models.Forms
{
    public class NewPersonForm
    {
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public PersonGender Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}
