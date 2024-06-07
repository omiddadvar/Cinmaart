namespace Cinamaart.WebAPI.Abstractions
{
    public sealed record WebserviceError
    (
        string Code,
        string? Description = null
    );
}
