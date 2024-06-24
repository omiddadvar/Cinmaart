using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories
{
    internal class TagRepository(MainDBContext dBContext) : 
        GenericRepository<Tag>(dBContext) , ITagRepository;
}
