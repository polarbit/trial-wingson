using WingsOn.Application.BaseObjects;
using WingsOn.Application.Dto.Resources;

namespace WingsOn.Application.Queries.GetCustomerById
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
