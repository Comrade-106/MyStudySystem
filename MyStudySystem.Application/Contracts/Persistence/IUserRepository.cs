﻿
using MyStudySystem.Domain.Entities;

namespace MyStudySystem.Application.Contracts.Persistence
{
    public interface IUserRepository : IBaseRepository<User>
    {
        //Task<User> GetByEmailAsync(string email);
    }
}
