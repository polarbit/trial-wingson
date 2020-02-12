using System;
using System.Collections.Generic;
using System.Linq;
using WingsOn.Domain.BaseObjects;

namespace WingsOn.Domain.Bookings.Entities
{
    public class Booking : DomainEntity
    {
        public Booking(int id, 
            string number, 
            Flight flight, 
            int customerId, 
            IEnumerable<Passenger> passengers, 
            DateTime dateBooking) : base(id)
        {
            Number = !string.IsNullOrWhiteSpace(number) ? number : throw new ArgumentNullException(nameof(number));
            Flight = flight ?? throw new ArgumentNullException(nameof(flight));
            CustomerId = customerId;
            Passengers = passengers ?? throw  new ArgumentNullException(nameof(passengers));
            DateBooking = dateBooking;

            if (!passengers.Any())
            {
                throw new ArgumentException("At least one passenger is required to create a booking.", nameof(passengers));
            }
        }

        public string Number { get; }

        public Flight Flight { get; }

        public int CustomerId { get; }

        public IEnumerable<Passenger> Passengers { get; }

        public DateTime DateBooking { get; }
    }
}
