using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.Bookings.Helpers;
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
                .Select(x => x.ToResource());

            return Task.FromResult(result);
        }
    }
}