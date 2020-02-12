using System;
using WingsOn.Domain.BaseObjects;
using WingsOn.Domain.Shared.Enums;
using WingsOn.Domain.Shared.Values;

namespace WingsOn.Domain.Customers
{
    public class Customer : DomainEntity
    {
        public Customer(
            int id,
            Address address,
            DateOfBirth dateBirth,
            Email email,
            GenderType gender,
            FullName name) : base(id)
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

        public Email Email { get; private set; }

        public void UpdateEmail(Email email)
        {
            Email = email ?? throw new ArgumentNullException( nameof(email), "Email can not be null.");
        }
    }
}
