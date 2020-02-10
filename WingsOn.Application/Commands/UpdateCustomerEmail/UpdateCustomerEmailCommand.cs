using System;
using WingsOn.Application.BaseObjects;

namespace WingsOn.Application.Commands.UpdateCustomerEmail
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
}
