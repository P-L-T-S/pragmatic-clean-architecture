using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings;

public static class BookingErrors
{
    public static Error NotFound = new(
        "Booking.Found",
        "The booking with the specified ID was not found."
    );

    public static Error Overlap = new(
        "Booking.Overlap",
        "The current booking is overlapping with n existing one"
    );

    public static Error NotPending = new(
        "Booking.NotPending",
        "The booking with the specified ID is not pending.");
    
    public static Error NotConfirmed = new(
        "Booking.NotReserved",
        "The booking is not confirmed"
    );

    public static Error AlreadyStarted = new(
        "Booking.AlreadyStarted",
        "The booking has already started"
    );
}