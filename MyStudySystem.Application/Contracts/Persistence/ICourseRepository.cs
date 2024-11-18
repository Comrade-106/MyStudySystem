
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Contracts.Persistence
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<IReadOnlyList<Course>> GetCoursesByUserIdAsync(Guid userId);        
    }

}
