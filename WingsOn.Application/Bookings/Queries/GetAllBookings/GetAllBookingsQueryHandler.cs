using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.Bookings.Resources;
using WingsOn.Application.Shared.Enums;
using WingsOn.Domain.Bookings.Repositories;

namespace WingsOn.Application.Bookings.Queries.GetAllBookings
{
    public class GetAllBookingsQueryHandler : IQueryHandler<GetAllBookingsQuery, IEnumerable<BookingResource>>
    {
        private readonly IBookingRepository _bookingRepository;

        public GetAllBookingsQueryHandler(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Task<IEnumerable<BookingResource>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            var result = _bookingRepository
                .GetAll()
                .Select(x =>
                    new BookingResource
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        BookingNumber = x.Number,
                        DateBooking = x.DateBooking,
                        Flight = new FlightResource
                        {
                            Id = x.Flight.Id,
                            FlightNumber = x.Flight.Number,
                            DepartureAirportId = x.Flight.DepartureAirportId,
                            DepartureDate = x.Flight.DepartureDate,
                            ArrivalAirportId = x.Flight.ArrivalAirportId,
                            ArrivalDate = x.Flight.ArrivalDate,
                            Price = x.Flight.Price
                        },
                        Passengers = x.Passengers.Select(p =>
                            new PassengerResource
                            {
                                Id = p.Id,
                                Email = p.Email,
                                Name = p.Name,
                                DateBirth = p.DateBirth,
                                Gender = (Gender)  p.Gender
                            })
                    });

            return Task.FromResult(result);
        }
    }
}