using Cinamaart.Domain.Abstractions;
using Cinamaart.Domain.Entities.Pivots;

namespace Cinamaart.Domain.Entities
{
    public class Movie : IAuditablaEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public DateTime CraetedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        public ICollection<MovieArtist> MovieArtists { get; set; } = new List<MovieArtist>();
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<MovieSubtitle> MovieSubtitles { get; set; } = new List<MovieSubtitle>();
        public ICollection<MovieTag> MovieTags { get; set; } = new List<MovieTag>();
    }
}
