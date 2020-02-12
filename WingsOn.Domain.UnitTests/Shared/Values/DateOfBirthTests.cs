using System;
using WingsOn.Domain.Shared.Values;
using Xunit;

namespace WingsOn.Domain.UnitTests.Shared.Values
{
    public class DateOfBirthTests
    {
        [Fact]
        public void Test_ValidDateOfBirth()
        {
            // Act
            _ = new DateOfBirth(new DateTime(2019,1,1));
            _ = new DateOfBirth(2019, 1, 1);
        }

        [Fact]
        public void Test_TooOldAge_ShouldThrow()
        {
            // Arrage
            var date = DateTime.Today.AddYears(-151);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => new DateOfBirth(date));
            Assert.Contains("DateOfBirth should be older than 150 years.", ex.Message);
        }

        [Fact]
        public void Test_NotBorneAge_ShouldThrow()
        {
            // Arrange
            DateTime date = DateTime.Today.AddYears(1);

            // Act
            var ex = Assert.Throws<ArgumentException>(() => new DateOfBirth(date));
            Assert.Contains("DateOfBirth should not be later than today.", ex.Message);
        }

        [Fact]
        public void Test_DateOfBirth_To_DateTimeCasting()
        {
            // Arrange
            DateOfBirth dateOfBirth = new DateOfBirth(new DateTime(2019,1,1));

            // Act
            DateTime date = dateOfBirth;

            // Assert
            Assert.Equal(dateOfBirth, date, new TimeSpan(1,0,0,0));
            Assert.Equal(dateOfBirth.GetHashCode(), date.GetHashCode());
            Assert.Equal(dateOfBirth.ToString(), date.ToString("yyyy-MM-dd"));
            Assert.True(dateOfBirth.Equals(date));
        }

        [Fact]
        public void Test_DateOfBirth_To_NullableDateTimeCasting()
        {
            // Arrange
            DateOfBirth dateOfBirth = new DateOfBirth(new DateTime(2019, 1, 1));

            // Act
            DateTime? date = dateOfBirth;

            // Assert
            Assert.NotNull(date);
            Assert.Equal(dateOfBirth, date.Value, new TimeSpan(1, 0, 0, 0));
            Assert.Equal(dateOfBirth.GetHashCode(), date.GetHashCode());
            Assert.Equal(dateOfBirth.ToString(), date.Value.ToString("yyyy-MM-dd"));
            Assert.True(dateOfBirth.Equals(date));
        }

        [Fact]
        public void Test_NullableDateTime_To_DateOfBirthCasting()
        {
            // Arrange
            DateTime? date = new DateTime(2019, 1, 1);

            // Act
            DateOfBirth dateOfBirth = date;

            // Assert
            Assert.Equal(dateOfBirth, date.Value, new TimeSpan(1, 0, 0, 0));
            Assert.Equal(date.GetHashCode(), date.GetHashCode());
            Assert.Equal(date.Value.ToString("yyyy-MM-dd"), dateOfBirth.ToString());
            Assert.True(dateOfBirth.Equals(date));
        }

        [Fact]
        public void Test_NullDateOfBirth_To_DateTimeCasting_ShouldThrow()
        {
            // Arrange
            DateOfBirth dateOfBirth = null;

            // Assert
            Assert.Throws<ArgumentNullException>(() => (DateTime)dateOfBirth);
        }

        [Fact]
        public void Test_NullDateOfBirth_To_NullableDateTimeCasting_ShouldBeNull()
        {
            // Arrange
            DateOfBirth dateOfBirth = null;

            // Act
            DateTime? date = dateOfBirth;

            // Assert
            Assert.Null(date);
        }

        [Fact]
        public void Test_NullableDateTime_To_DateOfBirthCasting_ShouldBeNull()
        {
            // Arrange
            DateTime? date = null;

            // Act
            DateOfBirth dateOfBirth = date;

            // Assert
            Assert.Null(dateOfBirth);
        }
    }
}
