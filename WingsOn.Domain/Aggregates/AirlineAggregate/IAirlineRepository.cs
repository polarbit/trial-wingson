using System.Collections.Generic;

namespace WingsOn.Domain.Aggregates.AirlineAggregate
{
    public interface IAirlineRepository
    {
        Airline GetById(int id);

        IEnumerable<Airline> GetAll();
    }
}