using System;
using WingsOn.Application.Enums;

namespace WingsOn.Application.Bookings.Resources
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
