using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WingsOn.Domain.ValueObjects
{
    public class Address
    {
        private readonly string _address;

        public Address(string address)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentNullException();

            if (address.Length > 200)
                throw new ArgumentException("Address length should be less than or equal to 200 characters.");

            if (address.Length < 5)
                throw new ArgumentException("Address length should be at least 5 characters.");

            _address = address;
        }

        public static implicit operator string(Address address) => address?._address!;

        public static implicit operator Address(string address) =>  address != null ? new Address(address) : null!;

        public override string ToString()
        {
            return _address;
        }

        public override int GetHashCode()
        {
            return _address.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is string s)
            {
                return _address.Equals(s);
            }

            if (obj is Address n)
            {
                return _address.Equals(n._address);
            }

            return false;
        }
    }
}
