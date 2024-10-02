using Cinamaart.Domain.Entities.Pivots;

namespace Cinamaart.Domain.Entities.Types
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public ICollection<TvSerieGenre> TvSerieGenres { get; set; } = new List<TvSerieGenre>();


    }
}
