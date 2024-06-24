using Cinamaart.Domain.Entities;
using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories
{
    internal class CountryRepository(MainDBContext dBContext) :
        GenericRepository<Country>(dBContext) , ICountryRepository;
}
