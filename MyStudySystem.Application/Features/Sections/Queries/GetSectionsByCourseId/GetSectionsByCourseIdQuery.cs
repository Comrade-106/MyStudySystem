
using MediatR;

namespace MyStudySystem.Application.Features.Sections.Queries.GetSectionsByCourseId
{
    public class GetSectionsByCourseIdQuery : IRequest<IReadOnlyList<SectionDto>>
    {
        public Guid CourseId { get; set; }
    }
}
