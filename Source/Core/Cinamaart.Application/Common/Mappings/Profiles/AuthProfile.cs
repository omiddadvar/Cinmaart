using AutoMapper;
using Cinamaart.Application.DTO;
using Cinamaart.Application.Features.Authentication.Commands.Login;

namespace Cinamaart.Application.Common.Mappings.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<LoginCommand, DeviceInfoDTO>();
        }
    }
}
