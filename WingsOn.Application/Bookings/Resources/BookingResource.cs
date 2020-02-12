using System;
using System.Collections.Generic;

namespace WingsOn.Application.Bookings.Resources
{
    public class BookingResource
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string BookingNumber { get; set; }

        public DateTime DateBooking { get; set; }

        public FlightResource Flight { get; set; }

        public IEnumerable<PassengerResource> Passengers { get; set; }
    }
}
