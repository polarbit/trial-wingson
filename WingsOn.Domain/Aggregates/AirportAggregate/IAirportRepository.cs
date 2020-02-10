using System.Collections.Generic;

namespace WingsOn.Domain.Aggregates.AirportAggregate
{
    public interface IAirportRepository
    {
        Airport GetById(int id);

        IEnumerable<Airport> GetAll();
    }
}
