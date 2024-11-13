
using MyStudySystem.Domain.Common;

namespace MyStudySystem.Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid UserId { get; private set; }
        public Language PreferredLanguage { get; private set; }

        public User(Guid userId, Language preferredLanguage)
        {
            UserId = userId;
            PreferredLanguage = preferredLanguage;
        }

        public void ChangePreferredLanguage(Language language)
        {
            PreferredLanguage = language;
        }
    }
}
