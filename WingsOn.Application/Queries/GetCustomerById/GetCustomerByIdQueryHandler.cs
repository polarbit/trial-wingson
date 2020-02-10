﻿using System;
using System.Threading;
using System.Threading.Tasks;
using WingsOn.Application.BaseObjects;
using WingsOn.Application.Dto.Enums;
using WingsOn.Application.Dto.Resources;
using WingsOn.Domain.Aggregates.CustomerAggregate;

namespace WingsOn.Application.Queries.GetCustomerById
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