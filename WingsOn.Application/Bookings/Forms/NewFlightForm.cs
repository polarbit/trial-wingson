using System;

namespace WingsOn.Application.Bookings.Forms
{
    public class NewFlightForm
    {
        public string FlightNumber { get; set; }

        public int DepartureAirportId { get; set; }

        public DateTime DepartureDate { get; set; }

        public int ArrivalAirportId { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int CarrierId { get; set; }

        public decimal Price { get; set; }
    }
}