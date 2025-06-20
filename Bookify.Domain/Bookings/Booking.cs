using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public sealed class Booking : Entity
{
    private Booking(
        Guid id,
        Guid apartmentId,
        Guid userId,
        DateRange duration,
        Money priceForPeriod,
        Money cleaningFee,
        Money amenitiesUpCharge,
        Money totalPrice,
        EBookingStatus status,
        DateTime createdOnUtc,
        DateTime? confirmedOnUtc,
        DateTime? rejectedOnUtc,
        DateTime? completedOnUtc,
        DateTime? cancelledOnUtc
    ) : base(id)
    {
        ApartmentId = apartmentId;
        UserId = userId;
        Duration = duration;
        PriceForPeriod = priceForPeriod;
        CleaningFee = cleaningFee;
        AmenitiesUpCharge = amenitiesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreatedOnUtc = createdOnUtc;
        ConfirmedOnUtc = confirmedOnUtc;
        RejectedOnUtc = rejectedOnUtc;
        CompletedOnUtc = completedOnUtc;
        CancelledOnUtc = cancelledOnUtc;
    }

    public Guid ApartmentId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceForPeriod { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public EBookingStatus Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }

    public static Booking Reserve(
        Guid apartmentId,
        Guid userId,
        DateRange duration,
        DateTime utcNow,
        PricingDetails pricingDetails
    )
    {
        var booking = new Booking(
            Guid.NewGuid(),
            apartmentId,
            userId,
            duration,
            pricingDetails.PriceForPeriod,
            pricingDetails.ApartmentCleaningFee,
            pricingDetails.AmenitiesUpCharge,
            pricingDetails.TotalPrice,
            EBookingStatus.Reserved,
            utcNow,
            null,
            null,
            null,
            null
        );

        return booking;
    }
}