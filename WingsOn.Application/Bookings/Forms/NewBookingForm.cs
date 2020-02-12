using System;
using System.Collections.Generic;

namespace WingsOn.Application.Bookings.Forms
{
    public class NewBookingForm
    {
        public string BookingNumber { get; set; }

        public int CustomerId { get; set; }

        public NewFlightForm Flight { get; set; }

        public DateTime DateBooking { get; set; }

        public List<NewPassengerForm> Passengers { get; set; }
    }
}
