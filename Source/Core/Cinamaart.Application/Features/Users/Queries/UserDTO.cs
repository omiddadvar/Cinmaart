namespace Cinamaart.Application.Features.Users.Queries
{
    public record UserDTO
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool LockedOut { get; set; }
    }
}
