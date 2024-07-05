using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;

namespace Cinamaart.Persistence.Repositories
{
    internal class TagRepository(MainDBContext dBContext) :
        GenericRepository<Tag>(dBContext), ITagRepository;
}
