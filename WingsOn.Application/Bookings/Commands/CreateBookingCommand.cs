using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.Bookings.Forms;
using WingsOn.Application.Bookings.Resources;

namespace WingsOn.Application.Bookings.Commands
{
    public class CreateBookingCommand : ICommand<BookingResource>
    {
        private readonly NewBookingForm _form;

        public CreateBookingCommand(NewBookingForm form)
        {
            _form = form;
        }
    }

    public class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand, BookingResource>
    {
        public Task<BookingResource> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
