using System;
using WingsOn.Domain.ValueObjects;
using Xunit;

namespace WingsOn.Domain.UnitTests.ValueObjects
{
    public class EmailTests
    {
        [Theory]
        [InlineData("a@b.com")]
        [InlineData("firstname_lastname@gmail.com")]
        [InlineData("a-b@gmail.co.uk")]
        public void Test_ValidEmail(string email)
        {
            // Act
            _ = new Email(email);
        }

        [Theory]
        [InlineData("invalid-email")]
        [InlineData("invalid-email@invalid-domain com")]
        [InlineData("www.wingson.com")]
        public void Test_InvalidEmail_ShouldThrow(string email)
        {
            // Act & Assert
            Assert.Throws<FormatException>(() => new Email(email));
        }

        [Fact]
        public void Test_WithNull_ShouldThrow()
        {
            // Act
            Assert.Throws<ArgumentNullException>(() => new Email(null));
        }

        [Fact]
        public void Test_WithEmptyString_ShouldThrow()
        {
            // Act
            Assert.Throws<ArgumentException>(() => new Email(""));
        }

        [Fact]
        public void Test_EmailToStringCasting()
        {
            // Arrange
            Email email = new Email("email@wingson.local");

            // Act
            string emailString = email;

            // Assert
            Assert.Equal(email, emailString);
            Assert.Equal(email.GetHashCode(), emailString.GetHashCode());
            Assert.Equal(email.ToString(), emailString);
            Assert.True(email.Equals(emailString));
        }

        [Fact]
        public void Test_StringToEmailCasting()
        {
            // Arrange
            string emailString = "email@wingson.local";

            // Act
            Email email = emailString;

            // Assert
            Assert.Equal(emailString, emailString);
            Assert.Equal(emailString.GetHashCode(), email.GetHashCode());
            Assert.Equal(emailString, email.ToString());
            Assert.True(email.Equals(emailString));
        }

        [Fact]
        public void Test_NullEmailToStringCasting_ShouldBeNull()
        {
            // Act
            string emailString = (Email)null;

            // Assert
            Assert.Null(emailString);
        }

        [Fact]
        public void Test_NullStringToEmailCasting_ShouldBeNull()
        {
            // Act
            Email email = (string) null;

            // Assert
            Assert.Null(email);
        }
    }
}
