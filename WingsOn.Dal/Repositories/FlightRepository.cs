using System;
using System.Globalization;
using System.Linq;
using WingsOn.Domain.Entities;

namespace WingsOn.Dal.Repositories
{
    public class FlightRepository : RepositoryBase<Flight>
    {
        public FlightRepository() 
        {
            AirportRepository airports = new AirportRepository();
            AirlineRepository airlines = new AirlineRepository();
            CultureInfo cultureInfo = new CultureInfo("nl-NL");

            Repository.AddRange(new []
            {
                new Flight
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
                new Flight
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
                new Flight
                (
                    id:41,
                    number: "BB339",
                    arrivalAirportId:  airports.GetAll().Single(a => a.Code == "ANH").Id,
                    arrivalDate:  DateTime.Parse("20/02/2000 17:50", cultureInfo),
                    departureAirportId:  airports.GetAll().Single(a => a.Code == "GJE").Id,
                    departureDate:  DateTime.Parse("20/02/2000 19:00", cultureInfo),
                    carrierId:  airlines.GetAll().Single(a => a.Code == "BB").Id,
                    price:  57.6m
                ),
                new Flight
                (
                    id:12,
                    number: "BB910",
                    arrivalAirportId:  airports.GetAll().Single(a => a.Code == "GJE").Id,
                    arrivalDate:  DateTime.Parse("17/07/2009 11:10", cultureInfo),
                    departureAirportId:  airports.GetAll().Single(a => a.Code == "OQO").Id,
                    departureDate:  DateTime.Parse("17/07/2009 13:45", cultureInfo),
                    carrierId:  airlines.GetAll().Single(a => a.Code == "BB").Id,
                    price:  185m
                ),
                new Flight
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
                new Flight
                (
                    id:21,
                    number: "BB768",
                    arrivalAirportId:  airports.GetAll().Single(a => a.Code == "ANH").Id,
                    arrivalDate:  DateTime.Parse("14/11/2006 21:00", cultureInfo),
                    departureAirportId:  airports.GetAll().Single(a => a.Code == "OQO").Id,
                    departureDate:  DateTime.Parse("15/11/2006 01:30", cultureInfo),
                    carrierId:  airlines.GetAll().Single(a => a.Code == "BB").Id,
                    price:  416.17m
                )
            });
        }
    }
}
