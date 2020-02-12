using System;

namespace WingsOn.Domain.Shared.Values
{
    public class FlightNumber
    {
        private readonly string _flightNumber;

        public FlightNumber(string flightNumber)
        {
            if (string.IsNullOrWhiteSpace(flightNumber))
                throw  new ArgumentNullException();

            if (flightNumber.Length > 10)
                throw new ArgumentException("The length of flight number should be less than or equal to 10 characters.");

            if (flightNumber.Length < 3)
            {
                throw  new ArgumentException("The length of flight number should be more than or equal to 3 characters.");
            }

            _flightNumber = flightNumber;
        }

        public static implicit operator string(FlightNumber fullname) => fullname?._flightNumber!;

        public static implicit operator FlightNumber(string fullname) => fullname != null ? new FlightNumber(fullname) : null!;

        public override string ToString()
        {
            return _flightNumber;
        }

        public override bool Equals(object obj)
        {
            if (obj is string s)
            {
                return _flightNumber.Equals(s);
            }

            if (obj is FlightNumber n)
            {
                return _flightNumber.Equals(n._flightNumber);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _flightNumber.GetHashCode();
        }
    }
}
