using System;
using System.Collections.Generic;
using System.Text;

namespace WingsOn.Domain.ValueObjects
{
    public class DateOfBirth
    {
        private readonly DateTime _dateOfBirth;

        public DateOfBirth(DateTime dateOfBirth)
        {
            if(dateOfBirth > DateTime.Today)
                throw  new ArgumentException("DateOfBirth should not be later than today.");

            if(dateOfBirth.AddYears(150) < DateTime.Today)
                throw  new ArgumentException("DateOfBirth should be older than 150 years.");

            _dateOfBirth = dateOfBirth;
        }

        public DateOfBirth(int year, int month, int day)
            : this(new DateTime(year, month, day))
        {

        }

        public static implicit operator DateTime(DateOfBirth dateOfBirth) => dateOfBirth?._dateOfBirth ?? throw  new ArgumentNullException();

        public static implicit operator DateTime?(DateOfBirth dateOfBirth) => dateOfBirth?._dateOfBirth;

        public static implicit operator DateOfBirth(DateTime dateOfBirth) => new DateOfBirth(dateOfBirth);

        public static implicit operator DateOfBirth(DateTime? dateOfBirth) => dateOfBirth.HasValue ? new DateOfBirth(dateOfBirth.Value) : null!;

        public override string ToString()
        {
            return _dateOfBirth.ToString("yyyy-MM-dd");
        }

        public override bool Equals(object obj)
        {
            if (obj is DateTime s)
            {
                return _dateOfBirth.Equals(s);
            }

            if (obj is DateOfBirth n)
            {
                return _dateOfBirth.Equals(n._dateOfBirth);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _dateOfBirth.GetHashCode();
        }
    }
}
