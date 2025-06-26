using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBooking;

internal sealed class BookingReservedDomainEventHandler
(
    IBookingRepository bookingRepository,
    IUserRepository userRepository,
    IEmailService emailService
)
    : INotificationHandler<BookingReservedDomainEvent>
{
    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await bookingRepository.GetById(notification.BookingId, cancellationToken);

        if (booking is null)
        {
            return;
        }

        var user = await userRepository.GetById(booking.UserId, cancellationToken);

        if (user is null)
        {
            return;
        }

        await emailService.Send(user.Email, "Booking reserved","You must to confirm your reservation");
    }
}