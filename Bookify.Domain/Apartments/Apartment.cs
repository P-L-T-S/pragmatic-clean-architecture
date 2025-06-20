using Bookify.Domain.Abstractions;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Apartments;

public sealed class Apartment
(
    Guid id,
    Name name,
    Description description,
    Address address,
    Money price,
    Money cleaningFee,
    DateTime? lastTimeBookedOnUtc,
    List<EAmenity> amenities
)
    : Entity(id)
{
    public Name Name { get; private set; } = name;
    public Description Description { get; private set; } = description;
    public Address Address { get; private set; } = address;
    public Money Price { get; private set; } = price;
    public Money CleaningFee { get; private set; } = cleaningFee;
    public DateTime? LastTimeBookedOnUtc { get; private set; } = lastTimeBookedOnUtc;
    public List<EAmenity> Amenities { get; private set; } = amenities;
}