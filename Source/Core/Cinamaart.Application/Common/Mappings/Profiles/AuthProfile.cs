using AutoMapper;
using Cinamaart.Application.DTO;
using Cinamaart.Application.Features.Authentication.Commands.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
