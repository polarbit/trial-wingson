namespace WingsOn.Domain.Aggregates.BookingAggregate
{
    public interface IBookingRepository
    {
        Booking GetById(int id);

        void Save(Booking booking);
    }
}
