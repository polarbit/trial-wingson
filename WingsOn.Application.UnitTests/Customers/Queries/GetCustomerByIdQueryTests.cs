using System;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using WingsOn.Application.Customers.Queries.GetCustomerById;
using WingsOn.Domain.Customers;
using Xunit;

namespace WingsOn.Application.UnitTests.Customers.Queries
{
    public class GetCustomerByIdQueryTests : TestBase
    {
        [Fact]
        public async Task Test_ForExistingCustomer_ShouldReturnCustomer()
        {
            // Arrange
            var mock = new Mock<ICustomerRepository>();
            var customer = Fixture.Create<Customer>();
            mock.Setup(foo => foo.GetById(customer.Id)).Returns(customer);
            var query = new GetCustomerByIdQuery(customer.Id);
            var queryHandler = new GetCustomerByIdQueryHandler(mock.Object);

            //  Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            //  Assert
            Assert.NotNull(result);
            Assert.Equal(customer.Id, result.Id);
            Assert.Equal(customer.Name, result.Name);
            Assert.Equal(customer.Address, result.Address);
            Assert.Equal(customer.Email, result.Email);
            Assert.Equal(customer.DateBirth, result.DateBirth, new TimeSpan(1,0,0,0));
        }

        [Fact]
        public async Task Test_ForNonExistingCustomer_ShouldReturnNull()
        {
            var mock = new Mock<ICustomerRepository>();
            mock.Setup(foo => foo.GetById(1)).Returns((Customer)null);
            var query = new GetCustomerByIdQuery(1);
            var queryHandler = new GetCustomerByIdQueryHandler(mock.Object);

            //  Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            //  Assert
            Assert.Null(result);
        }
    }
}
