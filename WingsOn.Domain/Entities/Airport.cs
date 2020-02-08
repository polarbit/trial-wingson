using WingsOn.Domain.BaseObjects;

namespace WingsOn.Domain.Entities
{
    public class Airport : DomainEntity
    {
        public Airport(int id, 
            string code, 
            string country, 
            string city) : base(id)
        {
            Code = code;
            Country = country;
            City = city;
        }

        public string Code { get; }

        public string Country { get; }

        public string City { get; }
    }
}
