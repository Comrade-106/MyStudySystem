
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Contracts.Persistence
{
    public interface IControlQuestionRepository : IBaseRepository<ControlQuestion>
    {
        Task<IReadOnlyList<ControlQuestion>> GetQuestionsBySectionIdAsync(Guid sectionId);
    }

}
