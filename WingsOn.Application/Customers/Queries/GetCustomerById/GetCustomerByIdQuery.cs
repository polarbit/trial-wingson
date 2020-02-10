using WingsOn.Application.BaseObjects;
using WingsOn.Application.Customers.Resources;

namespace WingsOn.Application.Customers.Queries.GetCustomerById
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
