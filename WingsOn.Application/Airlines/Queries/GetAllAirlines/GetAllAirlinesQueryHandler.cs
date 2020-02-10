using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.Airlines.Resources;
using WingsOn.Application.BaseObjects;
using WingsOn.Domain.Airlines;

namespace WingsOn.Application.Airlines.Queries.GetAllAirlines
{
    public class GetAllAirlinesQueryHandler : IQueryHandler<GetAllAirlinesQuery, IEnumerable<AirlineResource>>
    {
        private readonly IAirlineRepository _repository;

        public GetAllAirlinesQueryHandler(IAirlineRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<AirlineResource>> Handle(GetAllAirlinesQuery request, CancellationToken cancellationToken)
        {
            var result = _repository
                .GetAll()
                .Select(e =>
                    new AirlineResource
                    {
                        Code = e.Code,
                        Name = e.Name,
                        Address = e.Address
                    });

            return Task.FromResult(result);
        }
    }
}