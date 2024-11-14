
using AutoMapper;
using MyStudySystem.Application.Features.GlossaryEntries.Commands.CreateGlossaryEntry;
using MyStudySystem.Application.Features.GlossaryEntries.Commands.UpdateGlossaryEntry;
using MyStudySystem.Application.Features.GlossaryEntries.Queries.GetGlossaryEntryByCourseId;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateGlossaryEntryCommand, GlossaryEntry>()
                .ForMember(dest => dest.GlossaryEntryId, opt => opt.Ignore());

            CreateMap<UpdateGlossaryEntryCommand, GlossaryEntry>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<GlossaryEntry, GlossaryEntryDto>();
        }
    }
}
