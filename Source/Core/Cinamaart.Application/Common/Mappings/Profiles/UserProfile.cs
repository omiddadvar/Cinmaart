using AutoMapper;
using Cinamaart.Application.Features.Users.Commands.Register;
using Cinamaart.Application.Features.Users.Queries;
using Cinamaart.Domain.Entities.Identity;

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
