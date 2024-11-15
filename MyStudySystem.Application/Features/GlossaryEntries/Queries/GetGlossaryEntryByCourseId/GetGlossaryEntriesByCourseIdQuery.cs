
using MediatR;

namespace MyStudySystem.Application.Features.GlossaryEntries.Queries.GetGlossaryEntryByCourseId
{
    public class GetGlossaryEntriesByCourseIdQuery : IRequest<IReadOnlyList<GlossaryEntryDto>>
    {
        public Guid CourseId { get; set; }

        public GetGlossaryEntriesByCourseIdQuery(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
