using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Entities;
using Cinamaart.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories
{
    internal class AuthorRepository(MainDBContext dBContext) : 
        GenericRepository<Author>(dBContext), IAuthorRepository;
}
