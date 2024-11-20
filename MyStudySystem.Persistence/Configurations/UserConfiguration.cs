
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Configurations
{
    public class UserConfiguration : AuditableEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            // Игнорируем свойство PreferredLanguage, чтобы EF Core не пытался его сопоставить
            builder.Ignore(u => u.PreferredLanguage);

            // Остальные настройки...
        }
    }
}
