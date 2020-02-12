using System;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.Bookings.Resources;

namespace WingsOn.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand, BookingResource>
    {
        public Task<BookingResource> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}