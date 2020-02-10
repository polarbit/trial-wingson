namespace WingsOn.Domain.Bookings
{
    public interface IBookingRepository
    {
        Booking GetById(int id);

        void Save(Booking booking);
    }
}
