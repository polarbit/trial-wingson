using System;
using WingsOn.Application.BaseObjects;

namespace WingsOn.Application.Customers.Commands.UpdateCustomerEmail
{
    public class UpdateCustomerEmailCommand : ICommand
    {
        public UpdateCustomerEmailCommand(int customerId, string email)
        {
            CustomerId = customerId;
            Email = email;
        }

        public int CustomerId { get; }

        public string Email { get; }
    }
}
