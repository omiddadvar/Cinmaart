using AutoMapper;
using Cinamaart.Application.Features.Tags;
using Cinamaart.Application.Features.Tags.Commands.AddTag;
using Cinamaart.Application.Features.Tags.Commands.UpdateTag;
using Cinamaart.Domain.Entities.Types;

namespace Cinamaart.Application.Common.Mappings.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDTO>();
            CreateMap<AddTagCommand, Tag>();
            CreateMap<UpdateTagCommand, Tag>();
        }
    }
}
