using AutoMapper;
using Cinamaart.Application.Features.Users.Commands.Register;
using Cinamaart.Application.Features.Users.Queries;
using Cinamaart.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Common.Mappings.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<RegisterCommand, User>();
            CreateMap<User, UserDTO>();
        }
    }
}
