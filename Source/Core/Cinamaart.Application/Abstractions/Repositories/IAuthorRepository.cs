using Cinamaart.Application.Interfaces.Repositories;
using Cinamaart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Abstractions.Repositories
{
    public interface IAuthorRepository : IGenericRepository<Author>;
}
