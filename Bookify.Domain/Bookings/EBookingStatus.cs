namespace Bookify.Domain.Bookings;

public enum EBookingStatus
{
    Reserved = 1,
    Confirmed,
    Rejected,
    Cancelled,
    Completed
}