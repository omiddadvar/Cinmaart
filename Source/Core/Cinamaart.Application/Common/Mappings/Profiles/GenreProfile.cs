using AutoMapper;
using Cinamaart.Application.Features.Genres;
using Cinamaart.Application.Features.Genres.Commands.AddGenre;
using Cinamaart.Application.Features.Genres.Commands.UpdateGenre;
using Cinamaart.Domain.Entities.Types;

namespace Cinamaart.Application.Common.Mappings.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDTO>();
            CreateMap<AddGenreCommand, Genre>();
            CreateMap<UpdateGenreCommand, Genre>();
        }
    }
}
