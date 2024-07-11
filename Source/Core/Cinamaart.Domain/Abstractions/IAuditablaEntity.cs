namespace Cinamaart.Domain.Abstractions
{
    public interface IAuditablaEntity 
    {
        public DateTime CraetedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
