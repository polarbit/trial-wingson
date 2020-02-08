using System;
using System.Globalization;
using System.Linq;
using WingsOn.Domain.Entities;
using WingsOn.Domain.Enums;

namespace WingsOn.Dal.Repositories
{
    public class BookingRepository : RepositoryBase<Booking>
    {
        public BookingRepository() 
        {
            CustomerRepository persons = new CustomerRepository();
            FlightRepository flights = new FlightRepository();
            CultureInfo cultureInfo = new CultureInfo("nl-NL");

            Repository.AddRange(new []
            {
                new Booking
                (
                    id:  55,
                    number: "WO-291470",
                    customerId: persons.GetAll().Single(p => p.Name == "Branden Johnston").Id,
                    dateBooking: DateTime.Parse("03/03/2006 14:30", cultureInfo),
                    flightId: flights.GetAll().Single(f => f.Number == "BB768").Id,
                    passengers: new []
                    {
                        new Passenger 
                        (
                            id:  77,
                            address: "P.O. Box 795, 1956 Odio. Rd.",
                            dateBirth:  DateTime.Parse("01/01/1940", cultureInfo),
                            email:  "egestas.lacinia@Proinmi.com",
                            gender:  GenderType.Male,
                            name:  "Branden Johnston"
                        )
                    }
                ),
                new Booking
                (
                    id:  83,
                    number: "WO-151277",
                    customerId: persons.GetAll().Single(p => p.Name == "Debra Lang").Id,
                    dateBooking: DateTime.Parse("12/02/2000 12:55", cultureInfo),
                    flightId: flights.GetAll().Single(f => f.Number == "PZ696").Id,
                    passengers: new []
                    {
                        new Passenger 
                        (
                            id:  69,
                            address: "P.O. Box 344, 5822 Curabitur Rd.",
                            dateBirth:  DateTime.Parse("27/11/1948", cultureInfo),
                            email:  "non.cursus.non@turpisIncondimentum.co.uk",
                            gender:  GenderType.Female,
                            name:  "Claire Stephens"
                        ),
                        new Passenger
                        (
                            id:  91,
                            address: "805-1408 Mi Rd.",
                            dateBirth:  DateTime.Parse("24/09/1980", cultureInfo),
                            email:  "egestas.a.dui@aliquet.ca",
                            gender:  GenderType.Male,
                            name:  "Kendall Velazquez"
                        ),
                        new Passenger
                        (
                            id:  59,
                            address: "977-809 Morbi Avenue",
                            dateBirth:  DateTime.Parse("01/01/1958", cultureInfo),
                            email:  "et@dictumeleifendnunc.org",
                            gender:  GenderType.Female,
                            name:  "Zenia Stout"
                        )
                    }
                ),
                new Booking
                (
                    id:  34,
                    number: "WO-694142",
                    customerId: persons.GetAll().Single(p => p.Name == "Kathy Morgan").Id,
                    dateBooking: DateTime.Parse("13/02/2000 16:37", cultureInfo),
                    flightId: flights.GetAll().Single(f => f.Number == "PZ696").Id,
                    passengers: new []
                    {
                        new Passenger
                        (
                            id:  13,
                            address: "45200 Petterle Pass",
                            dateBirth:  DateTime.Parse("15/06/1910", cultureInfo),
                            gender:  GenderType.Female,
                            email:  "kmorgan1@lycos.com",
                            name:  "Kathy Morgan"
                        ),
                        new Passenger
                        (
                            id:  64,
                            address: "7 Buell Park",
                            dateBirth:  DateTime.Parse("04/10/1951" ,cultureInfo),
                            gender:  GenderType.Female,
                            name:  "Melissa Long",
                            email:  "mlong0@businesswire.com"
                        )
                    }
                ),
                new Booking
                (
                    id:  90,
                    number: "WO-139716",
                    customerId: persons.GetAll().Single(p => p.Name == "Bonnie Rice").Id,
                    dateBooking: DateTime.Parse("03/12/2011 16:50", cultureInfo),
                    flightId: flights.GetAll().Single(f => f.Number == "BB124").Id,
                    passengers: new []
                    {
                        new Passenger 
                        (
                            id:  40,
                            address: "3 Macpherson Junction",
                            dateBirth:  DateTime.Parse("16/11/1977", cultureInfo),
                            gender:  GenderType.Male,
                            email:  "brice5@hostgator.com",
                            name:  "Bonnie Rice"
                        ),
                        new Passenger
                        (
                            id:  18,
                            address: "2258 Sloan Avenue",
                            dateBirth:  DateTime.Parse("04/12/1962", cultureInfo),
                            gender:  GenderType.Female,
                            email:  "lharper6@adobe.com",
                            name:  "Louise Harper"
                        )
                    }
                )
            });
        }
    }
}
