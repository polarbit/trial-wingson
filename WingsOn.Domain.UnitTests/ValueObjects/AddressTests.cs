using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain.ValueObjects;
using Xunit;

namespace WingsOn.Domain.UnitTests.ValueObjects
{
    public class AddressTests
    {
        [Fact]
        public void Test_WithTooLongAddress_ShouldThrow()
        {
            // Arrange
            var tooLangAddress = "".PadLeft(201, 'A') ;

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => new Address(tooLangAddress));
            Assert.Contains("200 characters", ex.Message);
        }

        [Fact]
        public void Test_WitTooShortAddress_ShouldThrow()
        {
            // Arrange
            var tooShortAddress = "".PadLeft(3, 'A') ;

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => new Address(tooShortAddress)); 
            Assert.Contains("at least 5 characters", ex.Message);
        }
        

        [Fact]
        public void Test_WithNullParam_ShouldThrow()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Address(null));
        }

        [Fact]
        public void Test_WithEmptyParam_ShouldThrow()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new Address(""));
        }

        [Fact]
        public void Test_AddressToStringCasting()
        {
            // Arrange
            Address address = new Address("Too precise address 112358");

            // Act
            string addressString = address;

            // Arrange
            Assert.Equal(address, addressString);
            Assert.Equal(address.GetHashCode(), addressString.GetHashCode());
            Assert.Equal(address.ToString(), addressString);
            Assert.True(address.Equals(addressString));
        }


        [Fact]
        public void Test_StringToAddressCasting()
        {
            // Arrrange
            string addressString = "Too precise address 112358";

            // Act
            Address address = addressString;

            // Assert
            Assert.Equal(addressString, address);
            Assert.Equal(addressString.GetHashCode(), address.GetHashCode());
            Assert.Equal(addressString, address.ToString());
            Assert.True(address.Equals(addressString));
        }

        [Fact]
        public void Test_NullStringToAddressCasting_ShouldBeNull()
        {
            // Act
            Address address = (string) null;

            // Assert
            Assert.Null(address);
        }

        [Fact]
        public void Test_NullAddressToStringCasting_ShouldBeNull()
        {
            // Act
            string addressString = (Address) null;

            // Assert
            Assert.Null(addressString);
        }
    }
}
