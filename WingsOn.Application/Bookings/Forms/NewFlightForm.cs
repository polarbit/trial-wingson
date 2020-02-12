using System;
using System.ComponentModel.DataAnnotations;

namespace WingsOn.Application.Bookings.Forms
{
    public class NewFlightForm
    {
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string FlightNumber { get; set; }

        public int DepartureAirportId { get; set; }

        public DateTime DepartureDate { get; set; }

        public int ArrivalAirportId { get; set; }

        public DateTime ArrivalDate { get; set; }

        public int CarrierId { get; set; }

        public decimal Price { get; set; }
    }
}