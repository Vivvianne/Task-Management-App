using System;
using System.Collections.Generic;
using TaskManagement.Domain.Models.Users;

namespace TaskManagement.Domain.Services.Users
{
    /// <summary>
    /// Represents a user service
    /// </summary>
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUsersByEntityGuid(Guid userGuid);
        void InsertUser(User user);

        void UpdateUser(User user);

    }
}
