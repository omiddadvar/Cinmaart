namespace Cinamaart.Application.Features.Authentication.Queries
{
    public record AuthenticationResultDTO(
        string Token,
        DateTime TokenExpiresAt,
        string RefreshToken,
        DateTime RefreshTokenExpiresAt
        );
}
