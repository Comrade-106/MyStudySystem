using MyStudySystem.Domain.Common;

namespace MyStudySystem.Domain.Entities
{
    public class Course : AuditableEntity
    {
        public Guid CourseId { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public TimeSpan? Duration { get; private set; }
        public string? Url { get; private set; }
        public Guid UserId { get; private set; }

        private readonly List<Section> _sections = new List<Section>();
        public IReadOnlyCollection<Section> Sections => _sections.AsReadOnly();

        public Glossary Glossary { get; private set; }

        public Course(string title, string author, TimeSpan duration, string url, Guid userId)
        {
            CourseId = Guid.NewGuid();
            Title = title;
            Author = author;
            Duration = duration;
            Url = url;
            UserId = userId;
            Glossary = new Glossary();
        }

        public void AddSection(Section section)
        {
            if (section == null)
                throw new ArgumentNullException(nameof(section));

            _sections.Add(section);
        }

        public void RemoveSection(Section section)
        {
            _sections.Remove(section);
        }

        public void AddGlossaryEntry(GlossaryEntry entry)
        {
            Glossary.AddEntry(entry);
        }

        public void RemoveGlossaryEntry(GlossaryEntry entry)
        {
            Glossary.RemoveEntry(entry);
        }
    }

}
