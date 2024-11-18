using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Configurations
{
    public class ControlQuestionConfiguration : AuditableEntityConfiguration<ControlQuestion>
    {
        public override void Configure(EntityTypeBuilder<ControlQuestion> builder)
        {
            base.Configure(builder);

            builder.HasKey(q => q.QuestionId);

            builder.Property(q => q.QuestionText)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(q => q.AnswerText)
                .IsRequired()
                .HasMaxLength(1000);

            builder.HasOne<Section>()
                .WithMany(s => s.ControlQuestions)
                .HasForeignKey(q => q.SectionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
