using System;
using System.Collections.Generic;
using System.Text;

namespace WingsOn.Domain.Repositories
{
    public interface IBookingRepository
    {
        Booking GetById(int id);
    }
}
