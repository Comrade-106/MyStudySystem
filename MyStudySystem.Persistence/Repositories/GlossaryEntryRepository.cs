
using Microsoft.EntityFrameworkCore;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Repositories
{
    public class GlossaryEntryRepository : BaseRepository<GlossaryEntry>, IGlossaryEntryRepository
    {
        public GlossaryEntryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<GlossaryEntry>> GetEntriesByCourseIdAsync(Guid courseId)
        {
            return await _context.GlossaryEntries
                .Where(e => e.CourseId == courseId)
                .ToListAsync();
        }
    }
}
