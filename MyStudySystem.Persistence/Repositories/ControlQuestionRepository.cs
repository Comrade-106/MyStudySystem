
using Microsoft.EntityFrameworkCore;
using MyStudySystem.Application.Contracts.Persistence;
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Persistence.Repositories
{
    public class ControlQuestionRepository : BaseRepository<ControlQuestion>, IControlQuestionRepository
    {
        public ControlQuestionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<ControlQuestion>> GetQuestionsBySectionIdAsync(Guid sectionId)
        {
            return await _context.ControlQuestions
                .Where(q => q.SectionId == sectionId)
                .ToListAsync();
        }
    }
}
