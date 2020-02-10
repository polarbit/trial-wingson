using System;
using System.Collections.Generic;
using WingsOn.Domain.BaseObjects;

namespace WingsOn.Domain.Aggregates.BookingAggregate
{
    public class Booking : DomainEntity
    {
        public Booking(int id, 
            string number, 
            int flightId, 
            int customerId, 
            IEnumerable<Passenger> passengers, 
            DateTime dateBooking) : base(id)
        {
            Number = number;
            FlightId = flightId;
            CustomerId = customerId;
            Passengers = passengers;
            DateBooking = dateBooking;
        }

        public string Number { get; }

        public int FlightId { get; }

        public int CustomerId { get; }

        public IEnumerable<Passenger> Passengers { get; }

        public DateTime DateBooking { get; }
    }
}
