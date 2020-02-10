using System.Collections.Generic;

namespace WingsOn.Domain.Aggregates.CustomerAggregate
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);

        void Save(Customer person);
    }
}
