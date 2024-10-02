namespace Cinamaart.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; } = new List<Artist>();
        public ICollection<Movie> Movies { get; } = new List<Movie>();
        public ICollection<TvSerie> TvSeries { get; } = new List<TvSerie>();
    }
}
