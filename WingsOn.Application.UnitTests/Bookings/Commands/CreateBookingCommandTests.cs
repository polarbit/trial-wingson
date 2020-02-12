using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using WingsOn.Application.Bookings.Commands.CreateBooking;
using WingsOn.Application.Bookings.Forms;
using WingsOn.Application.Shared.Enums;
using WingsOn.Domain.Airlines;
using WingsOn.Domain.Airports;
using WingsOn.Domain.Bookings.Repositories;
using WingsOn.Domain.Customers;
using Xunit;

namespace WingsOn.Application.UnitTests.Bookings.Commands
{
    public class CreateBookingCommandTests : TestBase
    {
        [Fact]
        public async Task Test_WithValidForm()
        {
            // Arrange
            var customer = Fixture.Create<Customer>();
            var airport1 = new Airport(1, "IST", "TR", "IST");
            var airport2 = new Airport(1, "AMS", "NL", "AMS");
            var airline = new Airline(1, "TK", "THY", "Istanbul");
            //
            var bookingForm = new NewBookingForm
            {
                BookingNumber = "BN1X3",
                CustomerId = customer.Id,
                DateBooking = DateTime.UtcNow,
                Flight = new NewFlightForm
                {
                    FlightNumber = "TK1953",
                    DepartureDate = DateTime.Today,
                    DepartureAirportId = 1,
                    ArrivalDate = DateTime.Today.AddDays(1),
                    ArrivalAirportId = 2,
                    Price = 99,
                    CarrierId = 1
                },
                Passengers = new List<NewPassengerForm>
                {
                    new NewPassengerForm
                    {
                        Email = "email@wingson.local",
                        Address = "Some address",
                        Name = "Some Name",
                        Gender = Gender.Female,
                        DateBirth = new DateTime(2000,1,1)
                    }
                }
            };
            //
            var mockBooking = new Mock<IBookingRepository>();
            mockBooking.Setup(repo => repo.GetNextBookingId()).Returns(1);
            mockBooking.Setup(repo => repo.GetNextFlightId()).Returns(1);
            mockBooking.Setup(repo => repo.GetNextPassengerId()).Returns(1);
            //
            var mockCustomer = new Mock<ICustomerRepository>();
            mockCustomer.Setup(repo => repo.GetById(customer.Id)).Returns(customer);
            //
            var mockAirports = new Mock<IAirportRepository>();
            mockAirports.Setup(repo => repo.GetById(1)).Returns(airport1);
            mockAirports.Setup(repo => repo.GetById(2)).Returns(airport2);
            //
            var mockAirlines = new Mock<IAirlineRepository>();
            mockAirlines.Setup(repo => repo.GetById(1)).Returns(airline);
            //
            var command = new CreateBookingCommand(bookingForm);
            var commandHandler = new CreateBookingCommandHandler(mockBooking.Object, mockAirlines.Object, mockAirports.Object, mockCustomer.Object);

            // Act
            var result = await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(bookingForm.BookingNumber, result.BookingNumber);
            Assert.Equal(bookingForm.DateBooking, result.DateBooking);
            Assert.Equal(bookingForm.CustomerId, result.CustomerId);
            Assert.NotNull(result.Flight);
            Assert.Equal(bookingForm.Flight.FlightNumber, result.Flight.FlightNumber);
            Assert.NotNull(result.Passengers);
            Assert.NotEmpty(result.Passengers);
        }
    }
}
