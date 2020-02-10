using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Api.Application.BaseObjects;
using WingsOn.Api.Application.Dtos.Enums;
using WingsOn.Api.Application.Dtos.Resources;
using WingsOn.Domain.Aggregates.CustomerAggregate;

namespace WingsOn.Api.Application.Queries.GetAllCustomers
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