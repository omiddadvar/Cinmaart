namespace Cinamaart.Persistence.Abstractions
{
    public interface ISeeder
    {
        uint Order { get; }
        void Seed();
    }
}
