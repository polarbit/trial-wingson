using WingsOn.Domain.Bookings.Entities;

namespace WingsOn.Domain.Bookings.Repositories
{
    public interface IBookingRepository
    {
        Booking GetById(int id);

        void Save(Booking booking);
    }
}
