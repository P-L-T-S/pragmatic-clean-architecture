using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public record PricingDetails
(
    Money PriceForPeriod,
    Money ApartmentCleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice
);