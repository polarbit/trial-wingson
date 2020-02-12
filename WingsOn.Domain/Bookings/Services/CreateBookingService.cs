using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Customers;

namespace WingsOn.Domain.Bookings.Services
{
    public class CreateBookingService
    {
        public Booking CreateBooking(
            int id,
            string bookingNumber,
            Customer customer,
            DateTime bookingDate,
            Flight flight,
            IEnumerable<Passenger> passengers)
        {
            if (customer == null)
            {
                throw  new ArgumentNullException(nameof(customer), "Customer is required to create a booking.");
            }

            var booking = new Booking(id, bookingNumber, flight, customer.Id, passengers, bookingDate);

            // Creation validations.

            if (bookingDate >= DateTime.UtcNow)
            {
                throw  new ArgumentException("Booking date can not be later than now.", nameof(bookingDate));
            }

            if (bookingDate.AddYears(2) < DateTime.UtcNow)
            {
                throw new ArgumentException("Booking date can not be more than 2 years earlier than now.", nameof(bookingDate));
            }

            if (passengers.Count() > 9)
            {
                throw new ArgumentException("Max allowed number of passenger in a booking is 9.", nameof(passengers));
            }

            if (flight.DepartureDate > DateTime.UtcNow.AddYears(1))
            {
                throw new InvalidOperationException("It is not allowed to create bookings for flights which flight 1 year later than now.");
            }

            if (flight.DepartureDate <  DateTime.UtcNow.AddYears(-1))
            {
                throw new InvalidOperationException("It is not allowed to create bookings for flights which flight 1 year older than now.");
            }

            return booking;
        }
    }
}
