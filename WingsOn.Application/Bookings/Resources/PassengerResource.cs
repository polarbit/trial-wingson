using System;
using System.ComponentModel.DataAnnotations;
using WingsOn.Application.Shared.Enums;

namespace WingsOn.Application.Bookings.Resources
{
    public class PassengerResource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
