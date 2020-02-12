using System;

namespace WingsOn.Application.Bookings.Resources
{
    public class FlightResource
    {
        public int Id { get; set; }

        public string FlightNumber { get; set; }

        public int DepartureAirportId { get; set; }

        public DateTime DepartureDate { get; set; }

        public int ArrivalAirportId { get; set; }

        public DateTime ArrivalDate { get; set; }

        public decimal Price { get; set; }
    }
}
