using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WingsOn.Api.Application.BaseObjects;
using WingsOn.Domain.Aggregates.CustomerAggregate;

namespace WingsOn.Api.Application.Commands.UpdateCustomerEmail
{
    public class UpdateCustomerEmailCommand : ICommand
    {
        public UpdateCustomerEmailCommand(int customerId, string email)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            Email = email;
        }

        public Guid Id { get; }

        public int CustomerId { get; }

        public string Email { get; }
    }

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
            customerEntity.UpdateEmail(request.Email);

            _customerRepository.Save(customerEntity);

            return Unit.Task;
        }
    }
}
