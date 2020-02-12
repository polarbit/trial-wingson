using System;
using System.Collections.Generic;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Bookings.Services;
using WingsOn.Domain.Customers;
using WingsOn.Domain.Shared.Enums;
using WingsOn.Domain.Shared.Values;
using Xunit;

namespace WingsOn.Domain.UnitTests.Bookings.Services
{
    public class CreateBookingServiceTests
    {
        [Fact]
        public void Test_WithValidParams()
        {
            // Arrange
            var args = new SampleArguments();
            var action = BuildCreateBookingServiceCall(x => x.BookingDate = args.BookingDate);

            // Act
            var booking = action();

            // Assert
            Assert.Equal(args.Id, booking.Id);
            Assert.Equal(args.BookingNumber, booking.Number);
            Assert.Equal(args.Customer.Id, booking.CustomerId);
            Assert.Equal(args.BookingDate, booking.DateBooking);
            Assert.NotEmpty(booking.Passengers);
            Assert.NotNull(booking.Flight);
        }

        [Fact]
        public void Test_WithTooOldFlight_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateBookingServiceCall(args => args.Flight = CreateSampleFlight(departureDate: DateTime.Today.AddYears(-2)));

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(action);
            Assert.Contains("flight 1 year older than now", ex.Message);
        }

        [Fact]
        public void Test_WithTooFutureFlight_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateBookingServiceCall(args => args.Flight = CreateSampleFlight(departureDate: DateTime.Today.AddYears(2)));

            // Assert
            var ex = Assert.Throws<InvalidOperationException>(action);
            Assert.Contains("1 year later than now.", ex.Message);
        }

        [Fact]
        public void Test_WithTooMuchPassengers_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateBookingServiceCall(args =>
            {
                var newPassengers = new List<Passenger>();
                for (int i = 0; i < 10; i++)
                {
                    newPassengers.Add(CreateSamplePassenger( id:+1));
                }

                args.Passengers = newPassengers;
            });

            // Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("passengers", ex.ParamName);
            Assert.Contains("Max allowed number of passenger", ex.Message);
        }

        [Fact]
        public void Test_WithFutureBookingDate_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateBookingServiceCall(args => args.BookingDate = DateTime.Now.AddDays(1));

            // Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("bookingDate", ex.ParamName);
            Assert.Contains("later than now", ex.Message);
        }

        [Fact]
        public void Test_WithTooOldBookingDate_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateBookingServiceCall(args => args.BookingDate = DateTime.Now.AddYears(-2).AddDays(-1));

            // Assert
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("bookingDate", ex.ParamName);
            Assert.Contains("2 years earlier than now", ex.Message);
        }

        [Fact]
        public void Test_WithNullNumber_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateBookingServiceCall(args => args.BookingNumber = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("number", ex.ParamName);
        }

        [Fact]
        public void Test_WithNullCustomer_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateBookingServiceCall(args => args.Customer = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("customer", ex.ParamName);
        }

        [Fact]
        public void Test_WithNullFlight_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateBookingServiceCall(args => args.Flight = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("flight", ex.ParamName);
        }

        [Fact]
        public void Test_WithNullPassengers_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateBookingServiceCall(args => args.Passengers = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("passengers", ex.ParamName);
        }

        public class SampleArguments
        {
            public SampleArguments()
            {
                Id = 1;
                BookingNumber = "QX9Y6M";
                Customer = new Customer(1,
                    new Address("Some address 112358"),
                    new DateOfBirth(2000,1,1),
                    new Email("email@wingson.local"),
                    GenderType.Female,
                    "Name Lastname");
                BookingDate = DateTime.UtcNow;
                Flight = new Flight(1,
                    "TK1953",
                    1,
                    DateTime.Today,
                    2,
                    DateTime.Today.AddHours(1),
                    1,
                    99);
                Passengers = new List<Passenger>
                {
                    new Passenger(1,
                        "Name Lastname",
                        new DateOfBirth(2000, 1, 1),
                        GenderType.Female,
                        "Passenger address 112358",
                        "email@wingson.local")
                };
            }

            public int Id { get; set; }

            public string BookingNumber { get; set; }

            public Customer Customer { get; set; }

            public DateTime BookingDate { get; set; }

            public Flight Flight { get; set; }

            public IEnumerable<Passenger> Passengers { get; set; }
        }

        private Func<Booking> BuildCreateBookingServiceCall(Action<SampleArguments> argsModifier = null)
        {
            var createBookingService = new CreateBookingService();
            var args = new SampleArguments();

            argsModifier?.Invoke(args);

            return () => createBookingService.CreateBooking(args.Id,
                args.BookingNumber,
                args.Customer,
                args.BookingDate,
                args.Flight,
                args.Passengers);
        }

        private Passenger CreateSamplePassenger(int id)
        {
            return new Passenger(id,
                "Name Lastname",
                new DateOfBirth(2000, 1, 1),
                GenderType.Female,
                "Passenger address 112358",
                "email@wingson.local");
        }

        private Flight CreateSampleFlight(DateTime departureDate)
        {
            return new Flight(1,
                "TK1953",
                1,
                departureDate,
                2,
                departureDate.AddHours(3),
                1,
                99);
        }
    }
}
