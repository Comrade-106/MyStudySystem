
using AutoMapper;
using MyStudySystem.Application.Features.ControlQuestions.Commands.CreateControlQuestion;
using MyStudySystem.Application.Features.ControlQuestions.Commands.UpdateControlQuestion;
using MyStudySystem.Application.Features.ControlQuestions.Queries.GetControlQuestionsBySectionId;
using MyStudySystem.Application.Features.Courses.Commands.CreateCourse;
using MyStudySystem.Application.Features.Courses.Commands.UpdateCourse;
using MyStudySystem.Application.Features.Courses.Queries.GetCoursesByUserId;
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

            CreateMap<CreateCourseCommand, Course>()
                .ForMember(dest => dest.CourseId, opt => opt.Ignore());

            CreateMap<UpdateCourseCommand, Course>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Course, CourseDto>();

            CreateMap<CreateControlQuestionCommand, ControlQuestion>()
                .ForMember(dest => dest.QuestionId, opt => opt.Ignore());

            // Маппинг из команды обновления в существующую доменную модель
            CreateMap<UpdateControlQuestionCommand, ControlQuestion>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Маппинг из доменной модели в DTO
            CreateMap<ControlQuestion, ControlQuestionDto>();
        }
    }
}
