using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain.Entities;

namespace WingsOn.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);

        void Save(Customer person);
    }
}
