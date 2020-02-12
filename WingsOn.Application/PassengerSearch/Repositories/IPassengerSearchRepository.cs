using System;
using System.Collections.Generic;
using WingsOn.Application.Shared.Enums;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Shared.Values;

namespace WingsOn.Application.PassengerSearch.Repositories
{
    public interface IPassengerSearchRepository
    {
        IEnumerable<Passenger> GetPassengersByGender(Gender gender);

        IEnumerable<Passenger> GetPassengerByFlight(FlightNumber flightNumber);
    }
}
