
using MediatR;

namespace MyStudySystem.Application.Features.ControlQuestions.Queries.GetControlQuestionsBySectionId
{
    public class GetControlQuestionsBySectionIdQuery : IRequest<IReadOnlyList<ControlQuestionDto>>
    {
        public Guid SectionId { get; set; }
    }
}
