using System;
using WingsOn.Domain.Shared.Values;
using Xunit;

namespace WingsOn.Domain.UnitTests.Shared.Values
{
    public class FlightNumberTests
    {
        [Fact]
        public void Test_WithTooLongFlightNumber_ShouldThrow()
        {
            // Arrange
            var tooLongFlightNumber = "".PadLeft(11, 'A') ;

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => new FlightNumber(tooLongFlightNumber));
            Assert.Contains("10 characters", ex.Message);
        }

        [Fact]
        public void Test_WitTooShortFlightNumber_ShouldThrow()
        {
            // Arrange
            var tooShortFlightNumber = "".PadLeft(2, 'A') ;

            // Assert
            var ex = Assert.Throws<ArgumentException>(() => new FlightNumber(tooShortFlightNumber)); 
            Assert.Contains("3 characters", ex.Message);
        }
        

        [Fact]
        public void Test_WithNullParam_ShouldThrow()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new FlightNumber(null));
        }

        [Fact]
        public void Test_WithEmptyParam_ShouldThrow()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => new FlightNumber(""));
        }

        [Fact]
        public void Test_FlightNumberToStringCasting()
        {
            // Arrange
            FlightNumber flightNumber = new FlightNumber("TK1957");

            // Act
            string flightNumberString = flightNumber;

            // Arrange
            Assert.Equal(flightNumber, flightNumberString);
            Assert.Equal(flightNumber.GetHashCode(), flightNumberString.GetHashCode());
            Assert.Equal(flightNumber.ToString(), flightNumberString);
            Assert.True(flightNumber.Equals(flightNumberString));
        }


        [Fact]
        public void Test_StringToFlightNumberCasting()
        {
            // Arrrange
            string flightNumberString = "TK1706";

            // Act
            FlightNumber flightNumber = flightNumberString;

            // Assert
            Assert.Equal(flightNumberString, flightNumber);
            Assert.Equal(flightNumberString.GetHashCode(), flightNumber.GetHashCode());
            Assert.Equal(flightNumberString, flightNumber.ToString());
            Assert.True(flightNumber.Equals(flightNumberString));
        }

        [Fact]
        public void Test_NullStringToFlightNumberCasting_ShouldBeNull()
        {
            // Act
            FlightNumber flightNumber = (string) null;

            // Assert
            Assert.Null(flightNumber);
        }

        [Fact]
        public void Test_NullFlightNumberToStringCasting_ShouldBeNull()
        {
            // Act
            string flightNumberString = (FlightNumber) null;

            // Assert
            Assert.Null(flightNumberString);
        }
    }
}
