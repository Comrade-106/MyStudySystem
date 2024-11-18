using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyStudySystem.Domain.Common;

namespace MyStudySystem.Persistence.Configurations
{
    public abstract class AuditableEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CreatedBy)
                .HasMaxLength(100);

            builder.Property(e => e.LastModifiedBy)
                .HasMaxLength(100);

            builder.Property(e => e.CreatedDate)
                .IsRequired();
        }
    }
}
