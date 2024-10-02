namespace Cinamaart.Application.Features.Seasons
{
    public class SeasonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int TvSerieId { get; set; }
        public string TvSerie { get; set; }
    }
}
