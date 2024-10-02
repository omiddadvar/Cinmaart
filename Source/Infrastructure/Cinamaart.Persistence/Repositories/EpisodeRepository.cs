using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Entities;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Repositories
{
    internal class EpisodeRepository(MainDBContext dBContext) :
        GenericRepository<Episode>(dBContext), IEpisodeRepository;
}
