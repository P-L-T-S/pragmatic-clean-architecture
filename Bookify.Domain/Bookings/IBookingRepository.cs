using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task Add(Booking booking, CancellationToken cancellationToken = default);
    Task<bool> IsOverLapping(Apartment apartment, DateRange duration, CancellationToken cancellationToken = default);
}