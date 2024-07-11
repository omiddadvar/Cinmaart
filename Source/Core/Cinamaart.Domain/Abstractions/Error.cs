namespace Cinamaart.Domain.Abstractions
{
    public sealed record Error(string Code, string? Description = null)
    {
        public static readonly Error None = new Error(string.Empty);

        public static implicit operator Result<object>(Error error) => Result<object>.Failure(error);
    }
}
