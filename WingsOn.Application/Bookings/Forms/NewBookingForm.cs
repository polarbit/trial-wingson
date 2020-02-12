using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WingsOn.Application.Bookings.Forms
{
    public class NewBookingForm
    {
        [Required]
        [MinLength(5)]
        [MaxLength(10)]
        public string BookingNumber { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public NewFlightForm Flight { get; set; }

        public DateTime DateBooking { get; set; }

        [Required]
        public List<NewPassengerForm> Passengers { get; set; }
    }
}
