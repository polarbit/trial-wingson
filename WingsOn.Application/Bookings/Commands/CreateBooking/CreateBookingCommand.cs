using WingsOn.Application.BaseObjects;
using WingsOn.Application.Bookings.Forms;
using WingsOn.Application.Bookings.Resources;

namespace WingsOn.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommand : ICommand<BookingResource>
    {
        private readonly NewBookingForm _form;

        public CreateBookingCommand(NewBookingForm form)
        {
            _form = form;
        }
    }
}
