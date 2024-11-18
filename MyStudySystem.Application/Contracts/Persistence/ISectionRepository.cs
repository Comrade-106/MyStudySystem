
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Contracts.Persistence
{
    public interface ISectionRepository : IBaseRepository<Section>
    {
        Task<IReadOnlyList<Section>> GetSectionsByCourseIdAsync(Guid courseId);
    }

}
