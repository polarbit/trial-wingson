using System;
using System.Collections.Generic;
using System.Text;
using WingsOn.Domain.Entities;

namespace WingsOn.Domain.Repositories
{
    public interface IFlightRepository
    {
        Flight GetById(int id);

        void Save(Flight flight);
    }
}
