using WingsOn.Domain.BaseObjects;

namespace WingsOn.Domain.Aggregates.AirlineAggregate
{
    public class Airline : DomainEntity
    {
        public Airline(int id, 
            string code, 
            string name, 
            string address) : base(id)
        {
            Code = code;
            Name = name;
            Address = address;
        }

        public string Code { get; }

        public string Name { get; }

        public string Address { get; }
    }
}
