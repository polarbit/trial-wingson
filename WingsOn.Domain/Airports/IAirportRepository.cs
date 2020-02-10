using System.Collections.Generic;

namespace WingsOn.Domain.Airports
{
    public interface IAirportRepository
    {
        Airport GetById(int id);

        IEnumerable<Airport> GetAll();
    }
}
