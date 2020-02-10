namespace WingsOn.Domain.Aggregates.AirlineAggregate
{
    public interface IAirlineRepository
    {
        Airline GetById(int id);
    }
}