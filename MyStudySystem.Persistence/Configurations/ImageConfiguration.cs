
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Configurations
{
    public class ImageConfiguration : AuditableEntityConfiguration<Image>
    {
        public override void Configure(EntityTypeBuilder<Image> builder)
        {
            base.Configure(builder);

            builder.HasKey(i => i.ImageId);

            builder.Property(i => i.Data)
                .IsRequired();

            builder.Property(i => i.Description)
                .HasMaxLength(500);

            builder.HasOne<Content>()
                .WithMany(c => c.Images)
                .HasForeignKey(i => i.ContentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
