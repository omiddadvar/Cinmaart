using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Identity;

namespace Cinamaart.Domain.Entities
{
    public class Author : IBaseEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }
        public ICollection<Subtitle>? Subtitles { get; set; }

    }
}
