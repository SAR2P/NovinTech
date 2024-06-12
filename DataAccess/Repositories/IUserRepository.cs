﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUserAsync();

        Task<User> GetUserByIdAsync(int id);

        Task<User> CreateUserAsync(User user);

        Task UpdateUserAsync(User user);

        Task DeleteUserAsync(int id);

    }
}
