using System;
using WingsOn.Application.Dto.Enums;

namespace WingsOn.Application.Dto.Forms
{
    public class NewCustomerForm
    {
        public string Name { get; set; }

        public DateTime DateBirth { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }
    }
}