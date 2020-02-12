using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain.Airlines;
using WingsOn.Domain.Airports;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Bookings.Services;
using WingsOn.Domain.Shared.Values;
using Xunit;

namespace WingsOn.Domain.UnitTests.Bookings.Services
{
    public class CreateFlightServiceTests
    {
        [Fact]
        public void Test_WithValidParams()
        {
            // Arrange
            var args = new SampleArguments();
            var action = BuildCreateFlightServiceCall();

            // Act
            var flight = action();

            // Assert
            // Assert
            Assert.Equal(args.Id, flight.Id);
            Assert.Equal(args.FlightNumber, flight.Number);
            Assert.Equal(args.DepartureAirport.Id, flight.DepartureAirportId);
            Assert.Equal(args.DepartureDate, flight.DepartureDate);
            Assert.Equal(args.ArrivalAirport.Id, flight.ArrivalAirportId);
            Assert.Equal(args.ArrivalDate, flight.ArrivalDate);
            Assert.Equal(args.Carrier.Id, flight.CarrierId);
            Assert.Equal(args.Price, flight.Price);
        }

        [Fact]
        public void Test_WithNullDepartureAirport_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateFlightServiceCall(args => args.DepartureAirport = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("departureAirport", ex.ParamName);
        }

        [Fact]
        public void Test_WithNullArrivalAirport_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateFlightServiceCall(args => args.ArrivalAirport = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("arrivalAirport", ex.ParamName);
        }

        [Fact]
        public void Test_WithNullCarrier_ShouldThrow()
        {
            // Arrange
            var action = BuildCreateFlightServiceCall(args => args.Carrier = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("carrier", ex.ParamName);
        }

        public class SampleArguments
        {
            public SampleArguments()
            {
                Id = 1;
                DepartureAirport = new Airport(1, "IST", "TR", "IST");
                DepartureDate = DateTime.Today;
                ArrivalAirport = new Airport(2, "AMS", "NL", "AMS");
                ArrivalDate = DepartureDate.AddHours(3);
                Carrier = new Airline(1, "TK", "THY", "ISTANBUL");
                FlightNumber = "TK1953";
                Price = 99;
            }

            public int Id { get; set; }

            public Airport DepartureAirport { get; set; }

            public DateTime DepartureDate { get; set; }

            public Airport ArrivalAirport { get; set; }

            public DateTime ArrivalDate { get; set; }

            public Airline Carrier { get; set; }

            public FlightNumber FlightNumber { get; set; }

            public decimal Price { get; set; }
        }

        private Func<Flight> BuildCreateFlightServiceCall(Action<SampleArguments> argsModifier = null)
        {
            var createFlightService = new CreateFlightService();
            var args = new SampleArguments();

            argsModifier?.Invoke(args);

            return () => createFlightService.CreateFlight(args.Id,
                args.FlightNumber,
                args.DepartureAirport,
                args.DepartureDate,
                args.ArrivalAirport,
                args.ArrivalDate,
                args.Carrier,
                args.Price);
        }
    }
}
