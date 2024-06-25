using AutoMapper;
using Cinamaart.Application.Features.Artists.Queries.GetAllArtists;
using Cinamaart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Mappings.Profiles
{
    public class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            CreateMap<Artist, GetAllArtistsDTO>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Name));
            
        }
    }
}
