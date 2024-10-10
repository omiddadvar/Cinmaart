using Cinamaart.Application.Abstractions.Repositories;
using Cinamaart.Domain.Common.Enums;
using Cinamaart.Domain.Entities;
using Cinamaart.Domain.Entities.Identity;
using Cinamaart.Domain.Entities.Pivots;
using Cinamaart.Domain.Entities.Types;
using Cinamaart.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Persistence.Repositories
{
    public class DocumentRepository(MainDBContext dBContext) : 
        GenericRepository<Document>(dBContext), IDocumentRepository;
}
