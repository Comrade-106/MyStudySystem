
using MyStudySystem.Domain.Common;

namespace MyStudySystem.Domain.Entities
{
    public class Section : AuditableEntity
    {
        public Guid SectionId { get; private set; }
        public string Title { get; private set; }
        public Content Content { get; private set; }

        public Guid? ParentSectionId { get; private set; }
        public Section ParentSection { get; private set; }

        private readonly List<Section> _subsections = new List<Section>();
        public IReadOnlyCollection<Section> Subsections => _subsections.AsReadOnly();

        private readonly List<ControlQuestion> _controlQuestions = new List<ControlQuestion>();
        public IReadOnlyCollection<ControlQuestion> ControlQuestions => _controlQuestions.AsReadOnly();

        public Guid CourseId { get; private set; }

        public Section(string title, Content content, Guid courseId, Section parentSection = null)
        {
            SectionId = Guid.NewGuid();
            Title = title;
            Content = content;
            CourseId = courseId;
            ParentSection = parentSection;
            ParentSectionId = parentSection?.SectionId;
        }

        public void AddSubsection(Section subsection)
        {
            if (subsection == null)
                throw new ArgumentNullException(nameof(subsection));

            _subsections.Add(subsection);
        }

        public void RemoveSubsection(Section subsection)
        {
            _subsections.Remove(subsection);
        }

        public void AddControlQuestion(ControlQuestion question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            _controlQuestions.Add(question);
        }

        public void RemoveControlQuestion(ControlQuestion question)
        {
            _controlQuestions.Remove(question);
        }
    }

}
