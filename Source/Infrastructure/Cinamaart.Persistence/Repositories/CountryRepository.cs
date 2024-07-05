using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Entities;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Repositories
{
    internal class CountryRepository(MainDBContext dBContext) :
        GenericRepository<Country>(dBContext), ICountryRepository;
}
