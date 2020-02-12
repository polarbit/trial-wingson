using System;
using WingsOn.Domain.BaseObjects;
using WingsOn.Domain.Shared.Enums;
using WingsOn.Domain.Shared.Values;

namespace WingsOn.Domain.Bookings.Entities
{
    public class Passenger : DomainEntity
    {
        public Passenger(
            int id,
            FullName name,
            DateOfBirth dateBirth,
            GenderType gender,
            Address address,
            Email email) : base(id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "Name can not be null.");
            DateBirth = dateBirth ?? throw new ArgumentNullException(nameof(dateBirth), "DateOfBirth can not be null.");
            Gender = gender;
            Address = address ?? throw new ArgumentNullException(nameof(address), "Address can not be null.");
            Email = email ?? throw new ArgumentNullException(nameof(email), "Email can not be null.");
        }

        public FullName Name { get; }

        public DateOfBirth DateBirth { get; }

        public GenderType Gender { get; }

        public Address Address { get; }

        public Email Email { get; }
    }
}
