
namespace MyStudySystem.Application.Features.GlossaryEntries.Queries.GetGlossaryEntryByCourseId
{
    public class GlossaryEntryDto
    {
        public Guid GlossaryEntryId { get; set; }
        public string Term { get; set; } = string.Empty;
        public string Definition { get; set; } = string.Empty;
    }
}
