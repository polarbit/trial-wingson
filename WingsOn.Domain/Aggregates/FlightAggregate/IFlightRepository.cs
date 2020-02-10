namespace WingsOn.Domain.Aggregates.FlightAggregate
{
    public interface IFlightRepository
    {
        Flight GetById(int id);

        void Save(Flight flight);
    }
}
