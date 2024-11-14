
using MediatR;

namespace MyStudySystem.Application.Features.GlossaryEntries.Commands.UpdateGlossaryEntry
{
    public class UpdateGlossaryEntryCommand : IRequest
    {
        public Guid GlossaryEntryId { get; set; }
        public string Term { get; set; }
        public string Definition { get; set; }
    }
}
