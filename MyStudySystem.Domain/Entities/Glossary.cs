
using MyStudySystem.Domain.Common;

namespace MyStudySystem.Domain.Entities
{
    public class Glossary : AuditableEntity
    {
        private readonly List<GlossaryEntry> _entries = new List<GlossaryEntry>();
        public IReadOnlyCollection<GlossaryEntry> Entries => _entries.AsReadOnly();

        public void AddEntry(GlossaryEntry entry)
        {
            if (entry == null)
                throw new ArgumentNullException(nameof(entry));

            if (_entries.Any(e => e.Term == entry.Term))
                throw new InvalidOperationException("Term already exist.");

            _entries.Add(entry);
        }

        public void RemoveEntry(GlossaryEntry entry)
        {
            _entries.Remove(entry);
        }

        public GlossaryEntry FindEntry(string term)
        {
            return _entries.FirstOrDefault(e => e.Term.Equals(term, StringComparison.OrdinalIgnoreCase));
        }
    }

}
