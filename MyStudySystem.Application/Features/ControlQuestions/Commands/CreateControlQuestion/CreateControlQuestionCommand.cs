
using MediatR;

namespace MyStudySystem.Application.Features.ControlQuestions.Commands.CreateControlQuestion
{
    public class CreateControlQuestionCommand : IRequest<Guid>
    {
        public Guid SectionId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }
}
