using System;
using WingsOn.Domain.BaseObjects;
using WingsOn.Domain.Shared.Values;

namespace WingsOn.Domain.Bookings.Entities
{
    public class Flight : DomainEntity
    {
        public Flight(
            int id, 
            FlightNumber number,
            int departureAirportId, 
            DateTime departureDate,
            int arrivalAirportId, 
            DateTime arrivalDate,
            int carrierId,
            decimal price) : base(id)
        {
            Number = number ?? throw  new ArgumentNullException(nameof(number), "Number is required to construct a booking.");
            CarrierId = carrierId;
            DepartureAirportId = departureAirportId;
            DepartureDate = departureDate;
            ArrivalAirportId = arrivalAirportId;
            ArrivalDate = arrivalDate;
            Price = price;

            if (price < 0)
            {
                throw  new ArgumentException("Price should be greater than or equal to zero.", nameof(price));
            }

            if (DepartureDate >= ArrivalDate)
            {
                throw new ArgumentException("Departure date should be earlier than arrival date.", nameof(departureDate));
            }

            if (ArrivalDate.Subtract(DepartureDate) > new TimeSpan(24, 0, 0))
            {
                throw new ArgumentException("Max raw duration between departure and arrival dates should be less than 24 hours.", nameof(departureDate));
            }
        }

        public FlightNumber Number { get; }

        public int CarrierId { get; }

        public int DepartureAirportId { get; }

        public DateTime DepartureDate { get; }

        public int ArrivalAirportId { get; }

        public DateTime ArrivalDate { get; }

        public decimal Price { get; }
    }
}
