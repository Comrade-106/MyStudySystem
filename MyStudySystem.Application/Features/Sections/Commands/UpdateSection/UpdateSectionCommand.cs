
using MediatR;

namespace MyStudySystem.Application.Features.Sections.Commands.UpdateSection
{
    public class UpdateSectionCommand : IRequest
    {
        public Guid SectionId { get; set; }
        public string Title { get; set; }
    }
}
