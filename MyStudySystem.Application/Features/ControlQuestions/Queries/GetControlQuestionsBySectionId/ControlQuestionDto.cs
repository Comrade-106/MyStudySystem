
namespace MyStudySystem.Application.Features.ControlQuestions.Queries.GetControlQuestionsBySectionId
{
    public class ControlQuestionDto
    {
        public Guid QuestionId { get; set; }
        public Guid SectionId { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }
}
