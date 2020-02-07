using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WingsOn.Api.Models.Forms
{
    public class NewBookingForm
    {
        public string BookingNumber { get; set; }

        public int? CustomerId { get; set; }

        public int FlightId { get; set; }

        public DateTime DateBooking { get; set; }

        public List<NewPersonForm> Passengers { get; set; }

        public NewPersonForm Customer { get; set; }
    }
}
