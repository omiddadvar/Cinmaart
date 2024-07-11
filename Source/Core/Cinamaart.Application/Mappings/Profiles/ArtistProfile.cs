using AutoMapper;
using Cinamaart.Application.Features.Artists.Queries;
using Cinamaart.Domain.Entities;

namespace Cinamaart.Application.Mappings.Profiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, GetArtistDTO>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Name));

        }
    }
}
