using System;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.Customers.Resources;
using WingsOn.Application.Shared.Enums;
using WingsOn.Domain.Customers;

namespace WingsOn.Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler :
        IQueryHandler<GetCustomerByIdQuery, CustomerResource>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<CustomerResource> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));

            var customerEntity = _customerRepository.GetById(request.Id);

            if (customerEntity == null) return Task.FromResult((CustomerResource) null);

            return Task.FromResult(new CustomerResource
            {
                Id = customerEntity.Id,
                Name =  customerEntity.Name,
                Email = customerEntity.Email,
                DateBirth = customerEntity.DateBirth,
                Address = customerEntity.Address,
                Gender = (Gender) customerEntity.Gender
            });
        }
    }
}