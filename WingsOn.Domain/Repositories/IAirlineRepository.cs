using WingsOn.Domain.Entities;

namespace WingsOn.Domain.Repositories
{
    public interface IAirlineRepository
    {
        Airline GetById(int id);
    }
}