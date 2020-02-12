using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace WingsOn.Domain.ValueObjects
{
    public class Email
    {
        private readonly string _email;

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException">If the email parameter is null.</exception>
        /// <exception cref="ArgumentException">If the email parameter is empty.</exception>
        /// <exception cref="FormatException">If email address is invalid; FormatException will be thrown.</exception>
        public Email(string email)
        {
            _ = new MailAddress(email).Address;

            _email = email;
        }

        public static implicit operator string(Email email) => email?._email!;

        public static implicit operator Email(string email) => email != null ? new Email(email) : null!;

        public override string ToString()
        {
            return _email;
        }

        public override bool Equals(object obj)
        {
            if (obj is string s)
            {
                return _email.Equals(s);
            }

            if (obj is Email n)
            {
                return _email.Equals(n._email);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _email.GetHashCode();
        }
    }
}
