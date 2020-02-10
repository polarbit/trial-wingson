using System;
using System.Collections.Generic;
using WingsOn.Domain.BaseObjects;

namespace WingsOn.Domain.Bookings
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
            Number = number;
            Flight = flight;
            CustomerId = customerId;
            Passengers = passengers;
            DateBooking = dateBooking;
        }

        public string Number { get; }

        public Flight Flight { get; }

        public int CustomerId { get; }

        public IEnumerable<Passenger> Passengers { get; }

        public DateTime DateBooking { get; }
    }
}
