
namespace MyStudySystem.Application.Features.GlossaryEntries.Queries.GetGlossaryEntryByCourseId
{
    public class GetGlossaryEntriesByCourseIdQuery
    {
        public Guid CourseId { get; set; }

        public GetGlossaryEntriesByCourseIdQuery(Guid courseId)
        {
            CourseId = courseId;
        }
    }
}
