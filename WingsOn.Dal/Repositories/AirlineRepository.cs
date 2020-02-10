using WingsOn.Domain.Airlines;

namespace WingsOn.Dal.Repositories
{
    public class AirlineRepository : RepositoryBase<Airline>, IAirlineRepository
    {
        public AirlineRepository() 
        {
            Repository.AddRange(new []
            {
                new Airline
                (
                    id:8,
                    code: "PZ",
                    address: "P.O. Box 746, 3035 Urna. Av., Bailivre, Germany",
                    name: "Ultrices Aviation Ltd"
                ),
                new Airline
                (
                    id: 45,
                    code: "BB",
                    address: "985-9762 Semper Street, Saint-Prime, Bolivia",
                    name: "Proin Fly Corp"
                )
            });
        }

        Airline IAirlineRepository.GetById(int id)
        {
            return Get(id);
        }
    }
}
