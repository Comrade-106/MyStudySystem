
using MediatR;

namespace MyStudySystem.Application.Features.Sections.Commands.DeleteSection
{
    public class DeleteSectionCommand : IRequest
    {
        public Guid SectionId { get; set; }
    }
}
