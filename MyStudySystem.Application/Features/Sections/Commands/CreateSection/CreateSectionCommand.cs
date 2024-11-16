
using MediatR;

namespace MyStudySystem.Application.Features.Sections.Commands.CreateSection
{
    public class CreateSectionCommand : IRequest<Guid>
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public Guid? ParentSectionId { get; set; }
    }
}
