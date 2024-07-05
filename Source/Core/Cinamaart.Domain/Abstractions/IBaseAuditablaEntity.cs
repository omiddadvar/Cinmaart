namespace Cinamaart.Domain.Abstractions
{
    public interface IBaseAuditablaEntity
    {
        public DateTime CraetedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
