using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using WingsOn.Application.Bookings.Queries.GetAllBookings;
using WingsOn.Application.Customers.Queries.GetAllCustomers;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Bookings.Repositories;
using WingsOn.Domain.Customers;
using Xunit;

namespace WingsOn.Application.UnitTests.Bookings.Queries
{
    public class GetAllBookingsQueryTests : TestBase
    {
        [Fact]
        public async Task Test_ForExistingCustomers_ShouldReturnCustomers()
        {
            // Arrange
            var mock = new Mock<IBookingRepository>();
            Fixture.RepeatCount = 9;
            var bookings = Fixture.Create<Booking[]>();
            mock.Setup(foo => foo.GetAll()).Returns(bookings);
            var query = new GetAllBookingsQuery();
            var queryHandler = new GetAllBookingsQueryHandler(mock.Object);

            //  Act
            var result = await queryHandler.Handle(query, CancellationToken.None);

            //  Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(bookings.Length, result.Count());
        }
    }
}
