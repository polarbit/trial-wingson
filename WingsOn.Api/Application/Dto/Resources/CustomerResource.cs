using System;
using WingsOn.Api.Application.Dtos.Enums;

namespace WingsOn.Api.Application.Dtos.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}