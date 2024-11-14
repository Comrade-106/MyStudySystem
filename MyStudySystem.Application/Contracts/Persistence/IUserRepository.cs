
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<User> GetByEmailAsync(string email);
    }
}
