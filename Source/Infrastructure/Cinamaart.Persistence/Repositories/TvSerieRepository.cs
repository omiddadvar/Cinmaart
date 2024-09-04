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
    public class TvSerieRepository(MainDBContext dBContext) : 
        GenericRepository<TvSerie>(dBContext) , ITvSerieRepository;
}
