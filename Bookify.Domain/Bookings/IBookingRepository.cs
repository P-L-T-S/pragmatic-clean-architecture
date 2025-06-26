namespace Bookify.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking> GetById(Guid id, CancellationToken cancellationToken = default);
    Task Add(Booking booking, CancellationToken cancellationToken = default);
}