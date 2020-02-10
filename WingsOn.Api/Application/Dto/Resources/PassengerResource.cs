using System;
using WingsOn.Api.Application.Dtos.Enums;

namespace WingsOn.Api.Application.Dtos.Resources
{
    public class PassengerResource
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }
    }
}
