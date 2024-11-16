
namespace MyStudySystem.Application.Features.Sections.Queries.GetSectionsByCourseId
{
    public class SectionDto
    {
        public Guid SectionId { get; set; }
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string ContentText { get; set; }
        public Guid? ParentSectionId { get; set; }
        public List<SectionDto> Subsections { get; set; }
    }
}
