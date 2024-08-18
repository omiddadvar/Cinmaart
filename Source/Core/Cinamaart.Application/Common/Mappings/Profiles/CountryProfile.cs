using AutoMapper;
using Cinamaart.Application.Features.Countries;
using Cinamaart.Application.Features.Countries.Commands.AddCountry;
using Cinamaart.Application.Features.Countries.Commands.UpdateCountry;
using Cinamaart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Common.Mappings.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<AddCountryCommand, Country>();
            CreateMap<UpdateCountryCommand, Country>();
            CreateMap<Country, CountryDTO>().ReverseMap();
        }
    }
}
