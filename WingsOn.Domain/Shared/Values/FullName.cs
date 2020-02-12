using System;
using System.Linq;

namespace WingsOn.Domain.Shared.Values
{
    public class FullName
    {
        private readonly string _fullName;

        public FullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw  new ArgumentNullException();

            if (fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length <= 1)
                throw new ArgumentException("Fullname should contain at least two name parts.");

            if (fullName.Any(c => !char.IsWhiteSpace(c) && !char.IsLetter(c)))
                throw new ArgumentException("Fullname should only contain letters and whitespaces between parts.");

            if (fullName.Length > 50)
                throw new ArgumentException("Fullname length should be less than or equal to 50 characters.");

            _fullName = fullName;
        }

        public static implicit operator string(FullName fullname) => fullname?._fullName!;

        public static implicit operator FullName(string fullname) => fullname != null ? new FullName(fullname) : null!;

        public override string ToString()
        {
            return _fullName;
        }

        public override bool Equals(object obj)
        {
            if (obj is string s)
            {
                return _fullName.Equals(s);
            }

            if (obj is FullName n)
            {
                return _fullName.Equals(n._fullName);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _fullName.GetHashCode();
        }
    }
}
