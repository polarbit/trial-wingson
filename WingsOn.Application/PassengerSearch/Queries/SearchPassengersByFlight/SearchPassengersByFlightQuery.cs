using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.PassengerSearch.Resources;

namespace WingsOn.Application.PassengerSearch.Queries.SearchPassengersByFlight
{
    public class SearchPassengersByFlightQuery : IQuery<IEnumerable<PassengerResource>>
    {
        public SearchPassengersByFlightQuery(string flightNumber)
        {
            FlightNumber = flightNumber;
        }

        public string FlightNumber { get; }
    }
}
