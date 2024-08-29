using AutoMapper;
using Cinamaart.Application.Features.Tags;
using Cinamaart.Application.Features.Tags.Commands.AddTag;
using Cinamaart.Application.Features.Tags.Commands.UpdateTag;
using Cinamaart.Domain.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
