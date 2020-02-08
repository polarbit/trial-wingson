using System;
using WingsOn.Domain.BaseObjects;
using WingsOn.Domain.Enums;

namespace WingsOn.Domain.Entities
{
    public class Passenger : DomainEntity
    {
        public Passenger(
            int id,
            string name,
            DateTime dateBirth,
            GenderType gender,
            string address,
            string email) : base(id)
        {
            Name = name;
            DateBirth = dateBirth;
            Gender = gender;
            Address = address;
            Email = email;
        }

        public string Name { get; }

        public DateTime DateBirth { get; }

        public GenderType Gender { get; }

        public string Address { get; }

        public string Email { get; }
    }
}
