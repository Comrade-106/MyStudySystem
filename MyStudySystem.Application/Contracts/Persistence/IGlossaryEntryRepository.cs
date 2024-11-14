
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Contracts.Persistence
{
    public interface IGlossaryEntryRepository : IRepository<GlossaryEntry>
    {
        Task<IReadOnlyList<GlossaryEntry>> GetEntriesByCourseIdAsync(Guid courseId);
    }

}
