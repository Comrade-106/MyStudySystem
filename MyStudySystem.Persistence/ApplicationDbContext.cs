using Microsoft.EntityFrameworkCore;
using MyStudySystem.Domain.Entities;
using MyStudySystem.Persistence.Configurations;

namespace MyStudySystem.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ControlQuestion> ControlQuestions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<GlossaryEntry> GlossaryEntries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Content> Contents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ControlQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new GlossaryEntryConfiguration());
            modelBuilder.ApplyConfiguration(new ImageConfiguration());
            modelBuilder.ApplyConfiguration(new SectionConfiguration());
            modelBuilder.ApplyConfiguration(new ContentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
