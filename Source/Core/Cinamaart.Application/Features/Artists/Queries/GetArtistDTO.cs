namespace Cinamaart.Application.Features.Artists.Queries
{
    public class GetArtistDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
    }
}
