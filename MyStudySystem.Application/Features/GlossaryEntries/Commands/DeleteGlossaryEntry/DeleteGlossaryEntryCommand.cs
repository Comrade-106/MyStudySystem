
using MediatR;

namespace MyStudySystem.Application.Features.GlossaryEntries.Commands.DeleteGlossaryEntry
{
    public class DeleteGlossaryEntryCommand : IRequest
    {
        public Guid GlossaryEntryId { get; set; }
    }
}
