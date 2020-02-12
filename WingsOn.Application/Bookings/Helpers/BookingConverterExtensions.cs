using System.Linq;
using WingsOn.Application.Bookings.Resources;
using WingsOn.Application.Shared.Enums;
using WingsOn.Domain.Bookings.Entities;

namespace WingsOn.Application.Bookings.Helpers
{
    public static class BookingConverterExtensions
    {
        public static BookingResource ToResource(this Booking booking)
        {
            return new BookingResource
            {
                Id = booking.Id,
                CustomerId = booking.CustomerId,
                BookingNumber = booking.Number,
                DateBooking = booking.DateBooking,
                Flight = new FlightResource
                {
                    Id = booking.Flight.Id,
                    FlightNumber = booking.Flight.Number,
                    DepartureAirportId = booking.Flight.DepartureAirportId,
                    DepartureDate = booking.Flight.DepartureDate,
                    ArrivalAirportId = booking.Flight.ArrivalAirportId,
                    ArrivalDate = booking.Flight.ArrivalDate,
                    Price = booking.Flight.Price
                },
                Passengers = booking.Passengers.Select(p =>
                    new PassengerResource
                    {
                        Id = p.Id,
                        Email = p.Email,
                        Name = p.Name,
                        DateBirth = p.DateBirth,
                        Gender = (Gender)p.Gender,
                        Address = p.Address
                    })
            };
        }
    }
}
