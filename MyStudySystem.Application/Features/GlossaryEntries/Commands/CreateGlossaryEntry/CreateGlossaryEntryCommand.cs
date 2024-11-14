
using MediatR;

namespace MyStudySystem.Application.Features.GlossaryEntries.Commands.CreateGlossaryEntry
{
    public class CreateGlossaryEntryCommand : IRequest<Guid>
    {
        public Guid CourseId { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
    }
}
