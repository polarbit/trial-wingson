using System.Collections.Generic;

namespace WingsOn.Domain.Customers
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer GetById(int id);

        Customer GetByEmail(string email);

        void Save(Customer person);
    }
}
