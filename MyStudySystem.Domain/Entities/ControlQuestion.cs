
using MyStudySystem.Domain.Common;

namespace MyStudySystem.Domain.Entities
{
    public class ControlQuestion : AuditableEntity
    {
        public Guid QuestionId { get; private set; }
        public string QuestionText { get; private set; }
        public string AnswerText { get; private set; }

        public Guid SectionId { get; private set; }

        public ControlQuestion(string questionText, string answerText, Guid sectionId)
        {
            QuestionId = Guid.NewGuid();
            QuestionText = questionText;
            AnswerText = answerText;
            SectionId = sectionId;
        }

        public void UpdateQuestion(string questionText)
        {
            QuestionText = questionText;
        }

        public void UpdateAnswer(string answerText)
        {
            AnswerText = answerText;
        }
    }

}
