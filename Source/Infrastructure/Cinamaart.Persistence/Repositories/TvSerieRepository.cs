using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Entities;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Repositories
{
    public class TvSerieRepository(MainDBContext dBContext) :
        GenericRepository<TvSerie>(dBContext), ITvSerieRepository;
}
