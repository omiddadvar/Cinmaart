using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class MovieArtist
    {
        public long Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
