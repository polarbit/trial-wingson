using System;
using WingsOn.Domain.Airlines;
using WingsOn.Domain.Airports;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Shared.Values;

namespace WingsOn.Domain.Bookings.Services
{
    public class CreateFlightService
    {
        public Flight CreateFlight(int id,
            FlightNumber number,
            Airport departureAirport,
            DateTime departureDate,
            Airport arrivalAirport,
            DateTime arrivalDate,
            Airline carrier,
            decimal price)
        {
            if (departureAirport == null)
            {
                throw  new ArgumentNullException(nameof(departureAirport), "Departure airport is required to create a booking.");
            }

            if (arrivalAirport == null)
            {
                throw  new ArgumentNullException(nameof(arrivalAirport), "Arrival airport is required to create a booking.");
            }

            if (carrier == null)
            {
                throw  new ArgumentNullException(nameof(carrier), "Carrier is required to create a booking.");
            }

            var flight = new Flight(id, 
                number, 
                departureAirport.Id, 
                departureDate, 
                arrivalAirport.Id, 
                arrivalDate, 
                carrier.Id, 
                price);

            return flight;
        }
    }
}
