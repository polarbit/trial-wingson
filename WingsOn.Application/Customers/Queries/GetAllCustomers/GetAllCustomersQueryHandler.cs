using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.Customers.Resources;
using WingsOn.Application.Shared.Enums;
using WingsOn.Domain.Customers;

namespace WingsOn.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler :
        IQueryHandler<GetAllCustomersQuery, IEnumerable<CustomerResource>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<IEnumerable<CustomerResource>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));

            var customerEntities = _customerRepository.GetAll();

            return Task.FromResult(customerEntities.Select(customerEntity =>  new CustomerResource
            {
                Id = customerEntity.Id,
                Name =  customerEntity.Name,
                Email = customerEntity.Email,
                DateBirth = customerEntity.DateBirth,
                Address = customerEntity.Address,
                Gender = (Gender) customerEntity.Gender
            }));
        }
    }
}