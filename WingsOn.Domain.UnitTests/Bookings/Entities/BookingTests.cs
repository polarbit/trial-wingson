using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Shared.Enums;
using WingsOn.Domain.Shared.Values;
using Xunit;

namespace WingsOn.Domain.UnitTests.Bookings.Entities
{
    public class BookingTests
    {
        [Fact]
        public void Test_Create_WithValidParams()
        {
            // Arrange
            var args = new SampleBookingCreationArgs();
            var action = BuildBookingCreationFunc(x => x.DateBooking = args.DateBooking);

            // Act
            var booking = action();

            // Arrange
            Assert.Equal(args.Id, booking.Id);
            Assert.Equal(args.Number, booking.Number);
            Assert.Equal(args.CustomerId, booking.CustomerId);
            Assert.Equal(args.DateBooking, booking.DateBooking);
            Assert.NotEmpty(booking.Passengers);
            Assert.NotNull(booking.Flight);
        }

        [Fact]
        public void Test_Create_WithNullNumber_ShouldThrow()
        {
            // Arrange
            var action = BuildBookingCreationFunc(args => args.Number = null);

            // Act
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("number", ex.ParamName);
        }

        [Fact]
        public void Test_Create_WithNullFlight_ShouldThrow()
        {
            // Arrange
            var action = BuildBookingCreationFunc(args => args.Flight = null);

            // Act
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("flight", ex.ParamName);
        }

        [Fact]
        public void Test_Create_WithNullPassengers_ShouldThrow()
        {
            // Arrange
            var action = BuildBookingCreationFunc(args => args.Passengers = null);

            // Act
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("passengers", ex.ParamName);
        }

        [Fact]
        public void Test_Create_WithEmptyPassengers_ShouldThrow()
        {
            // Arrange
            var action = BuildBookingCreationFunc(args => args.Passengers = new Passenger[] {});

            // Act
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("passengers", ex.ParamName);
        }

        public class SampleBookingCreationArgs
        {
            public SampleBookingCreationArgs()
            {
                Id = 1;
                Number = "QX8AB6";
                Flight = new Flight(1,
                    "TK1953",
                    1,
                    DateTime.Today,
                    2,
                    DateTime.Today.AddHours(1),
                    1,
                    99);
                CustomerId = 1;
                Passengers = new List<Passenger>
                {
                    new Passenger(1,
                        "Name Lastname",
                        new DateOfBirth(2000, 1, 1),
                        GenderType.Female,
                        "Passenger address 112358",
                        "email@wingson.local")
                };
                DateBooking = DateTime.UtcNow;
            }

            public int Id { get; set; }

            public string Number { get; set; }

            public Flight Flight { get; set; }

            public int CustomerId { get; set; }

            public IEnumerable<Passenger> Passengers { get; set; }

            public DateTime DateBooking { get; set; }
        }

        private Func<Booking> BuildBookingCreationFunc(Action<SampleBookingCreationArgs> argsModifier = null)
        {
            var creationArgs = new SampleBookingCreationArgs();

            argsModifier?.Invoke(creationArgs);

            return () => new Booking(id: creationArgs.Id,
                number: creationArgs.Number,
                flight: creationArgs.Flight,
                customerId: creationArgs.CustomerId,
                passengers: creationArgs.Passengers,
                dateBooking: creationArgs.DateBooking);
        }
    }
}
