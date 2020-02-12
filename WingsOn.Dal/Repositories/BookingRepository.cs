using System;
using System.Globalization;
using System.Linq;
using WingsOn.Domain.Bookings;
using WingsOn.Domain.Bookings.Entities;
using WingsOn.Domain.Shared.Enums;

namespace WingsOn.Dal.Repositories
{
    public class BookingRepository : RepositoryBase<Booking>
    {
        public BookingRepository() 
        {
            CustomerRepository persons = new CustomerRepository();
            AirportRepository airports = new AirportRepository();
            AirlineRepository airlines = new AirlineRepository();
            CultureInfo cultureInfo = new CultureInfo("nl-NL");

            Repository.AddRange(new []
            {
                new Booking
                (
                    id:  55,
                    number: "WO-291470",
                    customerId: persons.GetAll().Single(p => p.Name == "Branden Johnston").Id,
                    dateBooking: DateTime.Parse("03/03/2006 14:30", cultureInfo),
                    flight: new Flight
                    (
                        id:21,
                        number: "BB768",
                        arrivalAirportId:  airports.GetAll().Single(a => a.Code == "ANH").Id,
                        arrivalDate:  DateTime.Parse("14/11/2006 21:00", cultureInfo),
                        departureAirportId:  airports.GetAll().Single(a => a.Code == "OQO").Id,
                        departureDate:  DateTime.Parse("15/11/2006 01:30", cultureInfo),
                        carrierId:  airlines.GetAll().Single(a => a.Code == "BB").Id,
                        price:  416.17m
                    ),
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
                    flight: new Flight
                    (
                        id:31,
                        number: "PZ956",
                        arrivalAirportId:  airports.GetAll().Single(a => a.Code == "ANH").Id,
                        arrivalDate:  DateTime.Parse("28/05/2008 20:10", cultureInfo),
                        departureAirportId:  airports.GetAll().Single(a => a.Code == "OQO").Id,
                        departureDate:  DateTime.Parse("29/05/2008 13:30", cultureInfo),
                        carrierId:  airlines.GetAll().Single(a => a.Code == "PZ").Id,
                        price:  1140.5m
                    ),
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
                    flight: new Flight
                    (
                        id:81,
                        number: "PZ696",
                        departureAirportId: airports.GetAll().Single(a => a.Code == "GJE").Id,
                        departureDate:  DateTime.Parse("20/02/2000 17:50", cultureInfo),
                        arrivalAirportId:   airports.GetAll().Single(a => a.Code == "CZR").Id,
                        arrivalDate:  DateTime.Parse("20/02/2000 19:00", cultureInfo),
                        carrierId:  airlines.GetAll().Single(a => a.Code == "PZ").Id,
                        price:  95.2m
                    ),
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
                    flight: new Flight
                    (
                        id: 30,
                        number: "BB124",
                        departureAirportId :  airports.GetAll().Single(a => a.Code == "OQO").Id,
                        departureDate: DateTime.Parse("12/02/2012 16:50", cultureInfo),
                        arrivalAirportId:  airports.GetAll().Single(a => a.Code == "GJE").Id,
                        arrivalDate: DateTime.Parse("13/02/2012 00:00", cultureInfo),
                        carrierId: airlines.GetAll().Single(a => a.Code == "BB").Id,
                        price: 196.1m
                    ),
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
