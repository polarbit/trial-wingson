using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain.Entities;

namespace WingsOn.Domain.Repositories
{
    public interface IAirportRepository
    {
        Airport GetById(int id);
    }
}
