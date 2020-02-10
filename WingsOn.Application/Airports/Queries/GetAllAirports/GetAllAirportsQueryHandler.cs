using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.Airports.Resources;
using WingsOn.Application.BaseObjects;
using WingsOn.Domain.Airports;

namespace WingsOn.Application.Airports.Queries.GetAllAirports
{
    public class GetAllAirportsQueryHandler : IQueryHandler<GetAllAirportsQuery, IEnumerable<AirportResource>>
    {
        private readonly IAirportRepository _repository;

        public GetAllAirportsQueryHandler(IAirportRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<AirportResource>> Handle(GetAllAirportsQuery request, CancellationToken cancellationToken)
        {
            var result = _repository
                .GetAll()
                .Select(e =>
                    new AirportResource
                    {
                        Code = e.Code,
                        City = e.City,
                        Country = e.Country
                    });

            return Task.FromResult(result);
        }
    }
}