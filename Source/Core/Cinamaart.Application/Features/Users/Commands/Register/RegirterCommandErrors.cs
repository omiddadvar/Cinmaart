using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Application.Features.Users.Commands.Register
{
    public static class RegirterCommandErrors
    {
        public static Error EmailNotConfirmed =
            new Error("Register.EmailNotConfirmed", "Email and ConfirmEmail values are not the same");
    }
}
