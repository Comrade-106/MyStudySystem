
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Contracts.Persistence
{
    public interface IGlossaryEntryRepository : IBaseRepository<GlossaryEntry>
    {
        Task<IReadOnlyList<GlossaryEntry>> GetEntriesByCourseIdAsync(Guid courseId);
    }

}
