
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Configurations
{
    public class CourseConfiguration : AuditableEntityConfiguration<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            base.Configure(builder);

            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Author)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Duration)
                .IsRequired(false);

            builder.Property(c => c.Url)
                .IsRequired(false)
                .HasMaxLength(500);

            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Sections)
                .WithOne()
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany<GlossaryEntry>()
                .WithOne()
                .HasForeignKey(ge => ge.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(c => c.Glossary);
        }
    }
}
