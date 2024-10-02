using Cinamaart.Domain.Abstractions;
using MediatR;

namespace Cinamaart.Application.Features.Users.Commands.Register
{
    public record RegisterCommand(
        string Username,
        string Email,
        string ConfirmEmail,
        string Password,
        string ConfirmPassword,
        string? PhoneNumber,
        string? FirstName,
        string? LastName
    ) : IRequest<Result<long?>>;
}
