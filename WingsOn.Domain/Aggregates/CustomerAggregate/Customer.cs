using System;
using WingsOn.Domain.BaseObjects;
using WingsOn.Domain.Enums;

namespace WingsOn.Domain.Aggregates.CustomerAggregate
{
    public class Customer : DomainEntity
    {
        public Customer(
            int id,
            string address,
            DateTime dateBirth,
            string email,
            GenderType gender,
            string name) : base(id)
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
