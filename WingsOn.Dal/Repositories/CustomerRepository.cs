using System;
using System.Globalization;
using WingsOn.Domain.Aggregates.CustomerAggregate;
using WingsOn.Domain.Enums;

namespace WingsOn.Dal.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository() 
        {
            CultureInfo cultureInfo = new CultureInfo("nl-NL");

            Repository.AddRange(new []
            {
                new Customer
                (
                    id:  77,
                    address: "P.O. Box 795, 1956 Odio. Rd.",
                    dateBirth:  DateTime.Parse("01/01/1940", cultureInfo),
                    email:  "egestas.lacinia@Proinmi.com",
                    gender:  GenderType.Male,
                    name:  "Branden Johnston"
                ),
                new Customer
                (
                    id:  25,
                    address: "4320 Tempor Rd.",
                    dateBirth:  DateTime.Parse("28/03/1959", cultureInfo),
                    email:  "elit@ligula.com",
                    gender:  GenderType.Female,
                    name:  "Debra Lang"
                ),
                new Customer
                (
                    id:  13,
		            address: "45200 Petterle Pass",
		            dateBirth:  DateTime.Parse("15/06/1910", cultureInfo),
		            gender:  GenderType.Female,
		            email:  "kmorgan1@lycos.com",
		            name:  "Kathy Morgan"
                ),
                new Customer
                (
                    id:  40,
		            address: "3 Macpherson Junction",
		            dateBirth:  DateTime.Parse("16/11/1977", cultureInfo),
		            gender:  GenderType.Male,
		            email:  "brice5@hostgator.com",
		            name:  "Bonnie Rice"
                )
            });
        }

        Customer ICustomerRepository.GetById(int id)
        {
            return Get(id);
        }
    }
}
