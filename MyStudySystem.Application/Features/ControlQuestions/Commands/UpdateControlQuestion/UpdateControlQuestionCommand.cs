
using MediatR;

namespace MyStudySystem.Application.Features.ControlQuestions.Commands.UpdateControlQuestion
{
    public class UpdateControlQuestionCommand : IRequest
    {
        public Guid QuestionId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }
}
