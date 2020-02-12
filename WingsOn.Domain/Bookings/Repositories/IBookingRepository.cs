using System.Collections.Generic;
using WingsOn.Domain.Bookings.Entities;

namespace WingsOn.Domain.Bookings.Repositories
{
    public interface IBookingRepository
    {
        Booking GetById(int id);

        IEnumerable<Booking> GetAll();

        void Save(Booking booking);
    }
}
