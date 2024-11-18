
using Microsoft.EntityFrameworkCore;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Repositories
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Section>> GetSectionsByCourseIdAsync(Guid courseId)
        {
            return await _context.Sections
                .Where(s => s.CourseId == courseId)
                .ToListAsync();
        }
    }
}
