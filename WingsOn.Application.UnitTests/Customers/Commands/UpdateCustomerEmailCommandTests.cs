using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using WingsOn.Application.Customers.Commands.UpdateCustomerEmail;
using WingsOn.Application.Customers.Queries.GetCustomerById;
using WingsOn.Domain.Customers;
using WingsOn.Domain.Shared.Values;
using Xunit;

namespace WingsOn.Application.UnitTests.Customers.Commands
{
    public class UpdateCustomerEmailCommandTests : TestBase
    {
        [Fact]
        public async Task Test_ForExistingCustomer_ShouldUpdateEmail()
        {
            // Arrange
            var mock = new Mock<ICustomerRepository>();
            var customer = Fixture.Create<Customer>();
            mock.Setup(foo => foo.GetById(customer.Id)).Returns(customer);
            var email = Fixture.Create<Email>();
            var command = new UpdateCustomerEmailCommand(customer.Id, email);
            var commandHandler = new UpdateCustomerEmailCommandHandler(mock.Object);

            //  Act
            await commandHandler.Handle(command, CancellationToken.None);

            // Assert
            mock.Verify(repo => repo.GetById(customer.Id));
            mock.Verify(repo => repo.Save(customer));
        }

        [Fact]
        public async Task Test_ForNonExistingCustomer_ShouldThrow()
        {
            var mock = new Mock<ICustomerRepository>();
            mock.Setup(foo => foo.GetById(1)).Returns((Customer)null);
            var email = Fixture.Create<Email>();
            var command = new UpdateCustomerEmailCommand(1, email);
            var commandHandler = new UpdateCustomerEmailCommandHandler(mock.Object);

            //  Assert
            var ex = await Assert.ThrowsAsync<ApplicationException>(async () => await commandHandler.Handle(command, CancellationToken.None));
            Assert.Contains("Customer not found", ex.Message);
            mock.Verify(repo => repo.GetById(1));
            mock.VerifyNoOtherCalls();
        }
    }
}
