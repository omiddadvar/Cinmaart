namespace Cinamaart.Domain.Abstractions
{
    public interface IBaseEntity<TPrimaryKey> : IEntity
    {
        public TPrimaryKey Id { get; set; }
    }
}
