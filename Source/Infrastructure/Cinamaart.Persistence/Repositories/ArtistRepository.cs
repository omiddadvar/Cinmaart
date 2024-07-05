using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Entities;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Repositories
{
    public class ArtistRepository(MainDBContext dBContext) :
        GenericRepository<Artist>(dBContext), IArtistRepository;
}
