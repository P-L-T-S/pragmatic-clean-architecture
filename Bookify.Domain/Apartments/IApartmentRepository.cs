namespace Bookify.Domain.Apartments;

public interface IApartmentRepository
{
    Task<Apartment?> GetById(Guid id, CancellationToken cancellationToken = default);
}