namespace Cinamaart.Domain.Abstractions
{
    public class PaginationDTO
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? OrderBy { get; set; }
    }
}
