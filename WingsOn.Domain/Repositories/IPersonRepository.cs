using System;
using System.Collections.Generic;
using System.Text;

namespace WingsOn.Domain.Repositories
{
    public interface IPersonRepository
    {
        Person GetById(int id);
    }
}
