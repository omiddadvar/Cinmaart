using AutoMapper;
using Cinamaart.Application.Features.Countries;
using Cinamaart.Application.Features.Countries.Commands.AddCountry;
using Cinamaart.Application.Features.Countries.Commands.UpdateCountry;
using Cinamaart.Domain.Entities;

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
