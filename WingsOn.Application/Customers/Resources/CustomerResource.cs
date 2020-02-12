using System;
using System.ComponentModel.DataAnnotations;
using WingsOn.Application.Shared.Enums;

namespace WingsOn.Application.Customers.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }
    }
}