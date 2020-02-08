using System;
using WingsOn.Domain.BaseObjects;

namespace WingsOn.Domain.Entities
{
    public class Flight : DomainEntity
    {
        public Flight(
            int id, 
            string number,
            int departureAirportId, 
            DateTime departureDate,
            int arrivalAirportId, 
            DateTime arrivalDate,
            int carrierId,
            decimal price) : base(id)
        {
            Number = number;
            CarrierId = carrierId;
            DepartureAirportId = departureAirportId;
            DepartureDate = departureDate;
            ArrivalAirportId = arrivalAirportId;
            ArrivalDate = arrivalDate;
            Price = price;
        }

        public string Number { get; }

        public int CarrierId { get; }

        public int DepartureAirportId { get; }

        public DateTime DepartureDate { get; }

        public int ArrivalAirportId { get; }

        public DateTime ArrivalDate { get; }

        public decimal Price { get; }
    }
}
