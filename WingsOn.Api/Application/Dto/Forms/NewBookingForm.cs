using System;
using System.Collections.Generic;

namespace WingsOn.Api.Application.Dtos.Forms
{
    public class NewBookingForm
    {
        public string BookingNumber { get; set; }

        public int? CustomerId { get; set; }

        public int FlightId { get; set; }

        public DateTime DateBooking { get; set; }

        public List<NewPassengerForm> Passengers { get; set; }

        public NewCustomerForm Customer { get; set; }
    }
}
