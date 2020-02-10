namespace WingsOn.Domain.Aggregates.AirportAggregate
{
    public interface IAirportRepository
    {
        Airport GetById(int id);
    }
}
