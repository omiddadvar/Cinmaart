using Cinamaart.Domain.Entities.Types;

namespace Cinamaart.Domain.Entities.Pivots
{
    public class MovieGenre
    {
        public long Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
