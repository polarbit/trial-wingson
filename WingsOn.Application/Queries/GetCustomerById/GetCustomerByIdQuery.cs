using System.Collections.Generic;
using System.Linq;
using WingsOn.Api.Application.BaseObjects;
using WingsOn.Api.Application.Dtos.Resources;

namespace WingsOn.Api.Application.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IQuery<CustomerResource>
    {
        public GetCustomerByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
