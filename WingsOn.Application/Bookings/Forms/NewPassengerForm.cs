using System;
using System.ComponentModel.DataAnnotations;
using WingsOn.Application.Shared.Enums;

namespace WingsOn.Application.Bookings.Forms
{
    public class NewPassengerForm
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public Gender Gender { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
