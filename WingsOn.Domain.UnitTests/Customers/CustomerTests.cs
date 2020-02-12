using System;
using WingsOn.Domain.Customers;
using WingsOn.Domain.Enums;
using WingsOn.Domain.ValueObjects;
using Xunit;

namespace WingsOn.Domain.UnitTests.Customers
{
    public class CustomerTests
    {
        [Fact]
        public void Test_Create_WithValidParams()
        {
            // Arrange
            var action = BuildCustomerCreationFunc();
            var args = new SampleCustomerCreationArguments();

            // Act
            var customer = action();

            // Assert
            Assert.NotNull(customer);
            Assert.Equal(args.Id, customer.Id);
            Assert.Equal(args.Name, customer.Name);
            Assert.Equal(args.Email, customer.Email);
            Assert.Equal(args.Address, customer.Address);
            Assert.Equal(args.Gender, customer.Gender);
        }

        [Fact]
        public void Test_UpdateEmail_WithNullParam_ShouldThrow()
        {
            // Arrange
            var customer = BuildCustomerCreationFunc()();
            void updateEmail() => customer.UpdateEmail(null);

            // Act
            var ex = Assert.Throws<ArgumentNullException>(updateEmail);
            Assert.Equal("email", ex.ParamName);
        }

        [Fact]
        public void UpdateEmail_WithValidParam()
        {
            // Arrange
            var customer = BuildCustomerCreationFunc()();
            var email = new Email("newemail@wingson.local");

            // Act
            customer.UpdateEmail(email);

            // Assert
            Assert.Equal(email, customer.Email);
        }

        [Fact]
        public void Test_Create_WithNullName_ShouldThrow()
        {
            // Arrange
            var action = BuildCustomerCreationFunc(arg => arg.Name = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("name", ex.ParamName);
        }

        [Fact]
        public void Test_Create_WithNullDateBirth_ShouldThrow()
        {
            // Arrange
            var action = BuildCustomerCreationFunc(arg => arg.DateBirth = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("dateBirth", ex.ParamName);
        }

        [Fact]
        public void Test_Create_WithNullAddress_ShouldThrow()
        {
            // Arrange
            var action = BuildCustomerCreationFunc(arg => arg.Address = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("address", ex.ParamName);
        }

        [Fact]
        public void Test_Create_WithNullEmail_ShouldThrow()
        {
            // Arrange
            var action = BuildCustomerCreationFunc(arg => arg.Email = null);

            // Assert
            var ex = Assert.Throws<ArgumentNullException>(action);
            Assert.Equal("email", ex.ParamName);
        }

        public class SampleCustomerCreationArguments
        {
            public int Id { get; set; } = 1;
            public DateOfBirth DateBirth { get; set; } = new DateOfBirth(2019, 1, 1);
            public FullName Name { get; set; } = "Name Lastname";
            public Address Address { get; set; } = new Address("Highly precise address 112358");
            public Email Email { get; set; } = new Email("email@wingson.local");
            public GenderType Gender { get; set; } = GenderType.Female;
        }

        private Func<Customer> BuildCustomerCreationFunc(Action<SampleCustomerCreationArguments> argsModifier = null)
        {
            var creationArgs = new SampleCustomerCreationArguments();

            argsModifier?.Invoke(creationArgs);

            return () => new Customer(creationArgs.Id,
                creationArgs.Address,
                creationArgs.DateBirth,
                creationArgs.Email,
                creationArgs.Gender,
                creationArgs.Name);
        }
    }
}
