using System;
using System.Collections.Generic;
using AutoFixture;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Shared.Enums;
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
            Fixture.Register<string>(() => "Something");

            Fixture.Register(() => new []
            {
                BuildBookingCreationFunc(args => args.Number = "TK1953")(),
                BuildBookingCreationFunc(args => args.Number = "KL2020")()
            });

        }

        public Fixture Fixture { get; }

        public void Dispose()
        {
            // ...
        }

        private class SampleBookingCreationArgs
        {
            public SampleBookingCreationArgs()
            {
                Id = 1;
                Number = "QX8AB6";
                Flight = new Flight(1,
                    "TK1953",
                    1,
                    DateTime.Today,
                    2,
                    DateTime.Today.AddHours(1),
                    1,
                    99);
                CustomerId = 1;
                Passengers = new List<Passenger>
                {
                    new Passenger(1,
                        "Name Lastname",
                        new DateOfBirth(2000, 1, 1),
                        GenderType.Female,
                        "Passenger address 112358",
                        "email@wingson.local")
                };
                DateBooking = DateTime.UtcNow;
            }

            public int Id { get; set; }

            public string Number { get; set; }

            public Flight Flight { get; set; }

            public int CustomerId { get; set; }

            public IEnumerable<Passenger> Passengers { get; set; }

            public DateTime DateBooking { get; set; }
        }

        private Func<Booking> BuildBookingCreationFunc(Action<SampleBookingCreationArgs> argsModifier = null)
        {
            var creationArgs = new SampleBookingCreationArgs();

            argsModifier?.Invoke(creationArgs);

            return () => new Booking(id: creationArgs.Id,
                number: creationArgs.Number,
                flight: creationArgs.Flight,
                customerId: creationArgs.CustomerId,
                passengers: creationArgs.Passengers,
                dateBooking: creationArgs.DateBooking);
        }
    }
}
