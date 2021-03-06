﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WingsOn.Application.BaseObjects;
using WingsOn.Domain.Customers;

namespace WingsOn.Application.Customers.Commands.UpdateCustomerEmail
{
    public class UpdateCustomerEmailCommandHandler : ICommandHandler<UpdateCustomerEmailCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerEmailCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Unit> Handle(UpdateCustomerEmailCommand request, CancellationToken cancellationToken)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));

            var customerEntity = _customerRepository.GetById(request.CustomerId);

            if (customerEntity == null)
            {
                throw new ApplicationException("Customer not found.");
            }

            customerEntity.UpdateEmail(request.Email);

            _customerRepository.Save(customerEntity);

            return Unit.Task;
        }
    }
}