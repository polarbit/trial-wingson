using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.Bookings.Helpers;
using WingsOn.Application.Bookings.Resources;
using WingsOn.Domain.Airlines;
using WingsOn.Domain.Airports;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Bookings.Repositories;
using WingsOn.Domain.Bookings.Services;
using WingsOn.Domain.Customers;
using WingsOn.Domain.Shared.Enums;

namespace WingsOn.Application.Bookings.Commands.CreateBooking
{
    public class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand, BookingResource>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IAirlineRepository _airlineRepository;
        private readonly IAirportRepository _airportRepository;
        private readonly ICustomerRepository _customerRepository;

        public CreateBookingCommandHandler(
            IBookingRepository bookingRepository,
            IAirlineRepository airlineRepository,
            IAirportRepository airportRepository,
            ICustomerRepository customerRepository)
        {
            _bookingRepository = bookingRepository;
            _airlineRepository = airlineRepository;
            _airportRepository = airportRepository;
            _customerRepository = customerRepository;
        }

        public Task<BookingResource> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            if (request.Form.Flight == null)
            {
                throw new ArgumentNullException(nameof(request.Form.Flight), "Flight form is required to create a booking.");
            }

            if (request.Form.Passengers == null)
            {
                throw new ArgumentNullException(nameof(request.Form.Flight), "Passenger forms is required to create a booking.");
            }

            // Create flight
            var flightForm = request.Form.Flight;
            var createFlightService = new CreateFlightService();
            var flight =createFlightService.CreateFlight(id: _bookingRepository.GetNextFlightId(),
                number: flightForm.FlightNumber,
                departureAirport: _airportRepository.GetById(flightForm.DepartureAirportId) ?? 
                                  throw new ArgumentException("Airport not found", nameof(flightForm.DepartureAirportId)),
                departureDate: flightForm.DepartureDate,
                arrivalAirport: _airportRepository.GetById(flightForm.ArrivalAirportId) ??
                                throw new ArgumentException("Airport not found", nameof(flightForm.DepartureAirportId)),
                arrivalDate: flightForm.ArrivalDate,
                carrier: _airlineRepository.GetById(flightForm.CarrierId) ??
                         throw new ArgumentException("Airline not found", nameof(flightForm.DepartureAirportId)),
                price: flightForm.Price);

            // Create passenger
            var passengers = new List<Passenger>();
            foreach (var passengerForm in request.Form.Passengers)
            {
                var passenger = new Passenger(id: _bookingRepository.GetNextPassengerId(),
                    name: passengerForm.Name,
                    email: passengerForm.Email,
                    address: passengerForm.Address,
                    gender: (GenderType) passengerForm.Gender,
                    dateBirth: passengerForm.DateBirth);
                passengers.Add(passenger);
            }

            // Create booking
            var createBookingService = new CreateBookingService();
            var booking = createBookingService.CreateBooking(id: _bookingRepository.GetNextBookingId(),
                bookingNumber: request.Form.BookingNumber,
                bookingDate: request.Form.DateBooking,
                passengers: passengers,
                flight: flight,
                customer: _customerRepository.GetById(request.Form.CustomerId)) ??
                          throw new ArgumentException("Customer not found", nameof(flightForm.DepartureAirportId));

            // Booking is successfully created in memory. Lets save it to db.
            _bookingRepository.Save(booking);

            return Task.FromResult(booking.ToResource());
        }
    }
}