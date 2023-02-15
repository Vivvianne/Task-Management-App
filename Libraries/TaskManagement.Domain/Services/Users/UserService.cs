using System;
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
