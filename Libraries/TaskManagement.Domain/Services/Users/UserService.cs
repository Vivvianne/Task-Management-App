using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Domain.Data.Infrastructure;
using TaskManagement.Domain.Models.Users;

namespace TaskManagement.Domain.Services.Users
{
    /// <summary>
    /// Represents a user service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IRepository<User> userRepository;

        public UserService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> GetUsers()
        {
            return userRepository.Table.ToList();
        }

        public User GetUsersByEntityGuid(Guid userGuid)
        {
            return (from userTable in userRepository.Table
                    where userTable.EntityGuid == userGuid
                    select userTable).FirstOrDefault();
        }

        public void InsertUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(User));

            userRepository.Insert(user);
        }

        public void UpdateUser(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(User));

            userRepository.Update(user);
        }
    }
}
