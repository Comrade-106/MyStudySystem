
using Microsoft.EntityFrameworkCore;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Repositories
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Course>> GetCoursesByUserIdAsync(Guid userId)
        {
            return await _context.Courses
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }
    }
}
