using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Configurations
{
    public class SectionConfiguration : AuditableEntityConfiguration<Section>
    {
        public override void Configure(EntityTypeBuilder<Section> builder)
        {
            base.Configure(builder);

            builder.HasKey(s => s.SectionId);

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasOne(s => s.ParentSection)
                .WithMany(s => s.Subsections)
                .HasForeignKey(s => s.ParentSectionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Course>()
                .WithMany(c => c.Sections)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.ControlQuestions)
                .WithOne()
                .HasForeignKey(cq => cq.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
