using System;
using AutoFixture;
using WingsOn.Domain.Shared.Values;
using Xunit;

namespace WingsOn.Application.UnitTests
{
    public abstract class TestBase : IDisposable
    {
        protected TestBase()
        {
            Fixture = new Fixture();
            Fixture.Register(() => new Email("email@wingson.local"));
            Fixture.Register(() => new Address("some address"));
            Fixture.Register(() => new FullName("Name Lastname"));
            Fixture.Register(() => new DateOfBirth(2000, 1, 1));
        }

        public Fixture Fixture { get; }

        public void Dispose()
        {
            // ...
        }
    }
}
