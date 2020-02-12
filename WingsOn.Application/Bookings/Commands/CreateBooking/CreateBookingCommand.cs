using System;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.Bookings.Forms;
using WingsOn.Application.Bookings.Resources;

namespace WingsOn.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : ICommand<BookingResource>
    {
        public NewBookingForm Form { get; }

        public CreateBookingCommand(NewBookingForm form)
        {
            Form = form ?? throw new ArgumentNullException(nameof(form));
        }
    }
}
