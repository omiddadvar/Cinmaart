namespace Cinamaart.Domain.Abstractions
{
    public interface IBaseTypeEntity : IBaseEntity<int>
    {
        string Name { get; set; }
    }
}
