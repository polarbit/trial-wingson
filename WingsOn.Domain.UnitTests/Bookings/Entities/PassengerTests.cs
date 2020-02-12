using System;
using WingsOn.Domain.Bookings;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Shared.Enums;
using WingsOn.Domain.Shared.Values;
using Xunit;

namespace WingsOn.Domain.UnitTests.Bookings
{
    public class PassengerTests
    {
        [Fact]
        public void Test_Create_WithValidParams()
        {
            // Arrange
            var action = BuildPassengerCreationFunc();
            var args = new SamplePassengerCreationArguments();

            // Act
            var passenger = action();

            // Assert
            Assert.NotNull(passenger);
            Assert.Equal(args.Id, passenger.Id);
            Assert.Equal(args.Name, passenger.Name);
            Assert.Equal(args.Email, passenger.Email);
            Assert.Equal(args.Address, passenger.Address);
            Assert.Equal(args.Gender, passenger.Gender);
            Assert.Equal(args.DateBirth, passenger.DateBirth);
        }

        [Fact]
        public void Test_Create_WithNullName_ShouldThrow()
        {
            // Arrange
            var action = BuildPassengerCreationFunc(arg => arg.Name = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("name", ex.ParamName);
        }

        [Fact]
        public void Test_Create_WithNullDateBirth_ShouldThrow()
        {
            // Arrange
            var action = BuildPassengerCreationFunc(arg => arg.DateBirth = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("dateBirth", ex.ParamName);
        }

        [Fact]
        public void Test_Create_WithNullAddress_ShouldThrow()
        {
            // Arrange
            var action = BuildPassengerCreationFunc(arg => arg.Address = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("address", ex.ParamName);
        }

        [Fact]
        public void Test_Create_WithNullEmail_ShouldThrow()
        {
            // Arrange
            var action = BuildPassengerCreationFunc(arg => arg.Email = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("email", ex.ParamName);
        }

        public class SamplePassengerCreationArguments
        {
            public int Id { get; set; } = 1;
            public DateOfBirth DateBirth { get; set; } = new DateOfBirth(2000, 1, 1);
            public FullName Name { get; set; } = "PaxName Lastname";
            public Address Address { get; set; } = new Address("Highly precise address 112358");
            public Email Email { get; set; } = new Email("email@wingson.local");
            public GenderType Gender { get; set; } = GenderType.Female;
        }

        private Func<Passenger> BuildPassengerCreationFunc(Action<SamplePassengerCreationArguments> argsModifier = null)
        {
            var creationArgs = new SamplePassengerCreationArguments();

            argsModifier?.Invoke(creationArgs);

            return () => new Passenger(id:creationArgs.Id,
                address: creationArgs.Address,
                dateBirth: creationArgs.DateBirth,
                email: creationArgs.Email,
                gender: creationArgs.Gender,
                name: creationArgs.Name);
        }
    }
}
