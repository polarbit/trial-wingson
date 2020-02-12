using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using WingsOn.Application.Customers.Queries.GetAllCustomers;
using WingsOn.Application.Customers.Queries.GetCustomerById;
using WingsOn.Domain.Customers;
using Xunit;

namespace WingsOn.Application.UnitTests.Customers.Queries
{
    public class GetAllCustomersQueryTests : TestBase
    {
        [Fact]
        public async Task Test_ForExistingCustomers_ShouldReturnCustomers()
        {
            // Arrange
            var mock = new Mock<ICustomerRepository>();
            Fixture.RepeatCount = 9;
            var customers = Fixture.Create<Customer[]>();
            mock.Setup(foo => foo.GetAll()).Returns(customers);
            var query = new GetAllCustomersQuery();
            var queryHandler = new GetAllCustomersQueryHandler(mock.Object);

            //  Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            //  Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(customers.Length, result.Count());
        }
    }
}
