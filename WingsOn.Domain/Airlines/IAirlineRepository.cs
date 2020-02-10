using System.Collections.Generic;

namespace WingsOn.Domain.Airlines
{
    public interface IAirlineRepository
    {
        Airline GetById(int id);

        IEnumerable<Airline> GetAll();
    }
}