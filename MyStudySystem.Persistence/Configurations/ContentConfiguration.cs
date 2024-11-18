
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Configurations
{
    public class ContentConfiguration : AuditableEntityConfiguration<Content>
    {
        public override void Configure(EntityTypeBuilder<Content> builder)
        {
            base.Configure(builder);

            builder.HasKey(c => c.ContentId);

            builder.Property(c => c.Text)
                .IsRequired(false);

            builder.HasOne<Section>()
                .WithOne(s => s.Content)
                .HasForeignKey<Content>(c => c.SectionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.Images)
                .WithOne()
                .HasForeignKey(i => i.ContentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
