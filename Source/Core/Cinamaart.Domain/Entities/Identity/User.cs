using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Pivots;
using Microsoft.AspNetCore.Identity;

namespace Cinamaart.Domain.Entities.Identity
{
    public class User : IdentityUser<long>
    {
        public string? FirstName {  get; set; }
        public string? LastName {  get; set; }

        public Author? Author { get; set; }
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<UserDocument> UserDocuments { get; set; } = new List<UserDocument>();

    }
}
