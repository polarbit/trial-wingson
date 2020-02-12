using System;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Shared.Enums;
using WingsOn.Domain.Shared.Values;
using Xunit;

namespace WingsOn.Domain.UnitTests.Bookings.Entities
{
    public class FlightTests
    {
        [Fact]
        public void Test_Create()
        {
            // Arrange
            var args = new SampleFlightCreationArguments();
            var action = BuildFlightCreationFunc();

            // Act
            var flight = action();

            // Assert
            Assert.Equal(args.Id, flight.Id);
            Assert.Equal(args.FlightNumber, flight.Number);
            Assert.Equal(args.DepartureAirportId, flight.DepartureAirportId);
            Assert.Equal(args.DepartureDate, flight.DepartureDate);
            Assert.Equal(args.ArrivalAirportId, flight.ArrivalAirportId);
            Assert.Equal(args.ArrivalDate, flight.ArrivalDate);
            Assert.Equal(args.CarrierId, flight.CarrierId);
            Assert.Equal(args.Price, flight.Price);
        }

        [Fact]
        public void Test_Create_WithNullNumber_ShouldThrow()
        {
            // Arrange
            var action = BuildFlightCreationFunc(args => args.FlightNumber = null);

            // Act
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("number", ex.ParamName);
        }

       [Fact]
       public void Test_Create_WithInvalidPrice_ShouldThrow()
        {
            // Arrange
            var action = BuildFlightCreationFunc(args => args.Price = -1);

            // Act
            var ex = Assert.Throws<ArgumentException>(action);
            Assert.Equal("price", ex.ParamName);
        }

       [Fact]
       public void Test_Create_WithDepartureDateIs_GreaterThanArrival_ShouldThrow()
       {
           // Arrange
           var action = BuildFlightCreationFunc(args => args.DepartureDate = args.ArrivalDate.AddHours(1));

           // Act
           var ex = Assert.Throws<ArgumentException>(action);
           Assert.Equal("departureDate", ex.ParamName);
       }

       [Fact]
       public void Test_Create_WithTooLongFlightDuration_ShouldThrow()
       {
           // Arrange
           var action = BuildFlightCreationFunc(args => args.ArrivalDate = args.DepartureDate.AddHours(30));

           // Act
           var ex = Assert.Throws<ArgumentException>(action);
           Assert.Equal("departureDate", ex.ParamName);
       }

        public class SampleFlightCreationArguments
        {
            public SampleFlightCreationArguments()
            {
                Id = 1;
                FlightNumber = "TK1957";
                DepartureAirportId = 1;
                DepartureDate = DateTime.Today.AddHours(10);
                ArrivalAirportId = 2;
                ArrivalDate = DateTime.Today.AddHours(12);
                CarrierId = 1;
                Price = 99;
            }

            public int Id { get; set; }

            public FlightNumber FlightNumber { get; set; }

            public int DepartureAirportId { get; set; }

            public DateTime DepartureDate { get; set; }

            public int ArrivalAirportId { get; set; }

            public DateTime ArrivalDate { get; set; }

            public int CarrierId { get; set; }

            public decimal Price { get; set; }
        }

        private Func<Flight> BuildFlightCreationFunc(Action<SampleFlightCreationArguments> argsModifier = null)
        {
            var creationArgs = new SampleFlightCreationArguments();

            argsModifier?.Invoke(creationArgs);

            return () => new Flight(id: creationArgs.Id,
                number: creationArgs.FlightNumber,
                departureAirportId: creationArgs.DepartureAirportId,
                departureDate: creationArgs.DepartureDate,
                arrivalAirportId: creationArgs.ArrivalAirportId,
                arrivalDate: creationArgs.ArrivalDate,
                carrierId: creationArgs.CarrierId,
                price: creationArgs.Price);
        }
    }
}
