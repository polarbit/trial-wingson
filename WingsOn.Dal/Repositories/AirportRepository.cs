using WingsOn.Domain.Aggregates.AirportAggregate;

namespace WingsOn.Dal.Repositories
{
    public class AirportRepository : RepositoryBase<Airport>, IAirportRepository
    {
        public AirportRepository()
        {
            Repository.AddRange(new []
            {
                new Airport
                (
                    id: 60,
                    code: "OQO",
                    city: "Zwijnaarde",
                    country: "Cuba"
                ),
                new Airport
                (
                    id: 98,
                    code: "GJE",
                    city: "Ottignies",
                    country: "Iran"
                ),
                new Airport
                (
                    id: 13,
                    code: "CZR",
                    city: "Okigwe",
                    country: "Mali"
                ),
                new Airport
                (
                    id: 80,
                    code: "ANH",
                    city: "Chiniot",
                    country: "Algeria"
                )
            });
        }

        Airport IAirportRepository.GetById(int id)
        {
            return Get(id);
        }
    }
}
