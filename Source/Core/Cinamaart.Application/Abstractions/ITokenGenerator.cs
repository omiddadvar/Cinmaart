using Cinamaart.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Abstractions
{
    public interface ITokenGenerator
    {
        Task<string> GenerateTokenAsync(User user);

    }
}
