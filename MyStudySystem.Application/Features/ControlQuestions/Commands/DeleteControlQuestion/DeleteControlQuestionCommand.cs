
using MediatR;

namespace MyStudySystem.Application.Features.ControlQuestions.Commands.DeleteControlQuestion
{
    public class DeleteControlQuestionCommand : IRequest
    {
        public Guid QuestionId { get; set; }
    }
}
