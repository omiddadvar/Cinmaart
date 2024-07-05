namespace Cinamaart.Domain.Abstractions
{
    public interface IAuditablaEntity<TPrimaryKey> : IBaseEntity<TPrimaryKey>, IBaseAuditablaEntity
    {
    }
}
