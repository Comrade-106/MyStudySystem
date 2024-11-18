using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Configurations
{
    public class GlossaryEntryConfiguration : AuditableEntityConfiguration<GlossaryEntry>
    {
        public override void Configure(EntityTypeBuilder<GlossaryEntry> builder)
        {
            base.Configure(builder);

            builder.HasKey(ge => ge.GlossaryEntryId);

            builder.Property(ge => ge.Term)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(ge => ge.Definition)
                .IsRequired()
                .HasMaxLength(2000);

            builder.HasOne<Course>()
                .WithMany()
                .HasForeignKey(ge => ge.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
