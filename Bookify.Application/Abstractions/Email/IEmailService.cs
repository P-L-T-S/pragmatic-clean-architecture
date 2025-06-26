namespace Bookify.Application.Abstractions.Email;

public interface IEmailService
{
    Task Send(Domain.Users.Email recipient, string subject, string body);
}