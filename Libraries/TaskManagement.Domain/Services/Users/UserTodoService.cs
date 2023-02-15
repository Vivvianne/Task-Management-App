using System;
using TaskManagement.Domain.Data.Infrastructure;
using TaskManagement.Domain.Models.Users;

namespace TaskManagement.Domain.Services.Users
{
    /// <summary>
    /// Represents a user todo service
    /// </summary>
    public class UserTodoService : IUserTodoService
    {
        private readonly IRepository<UserTodo> userTodoRepository;

        public UserTodoService(IRepository<UserTodo> userTodoRepository)
        {
            this.userTodoRepository = userTodoRepository;
        }


        /// <summary>
        /// Inserts a user todo
        /// </summary>
        /// <param name="userTodo">User todo</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void InsertUserTodo(UserTodo userTodo)
        {
            if (userTodo is null)
                throw new ArgumentNullException(nameof(UserTodo));

            userTodoRepository.Insert(userTodo);
        }

        /// <summary>
        /// Updates a user todo 
        /// </summary>
        /// <param name="userTodo">User todo</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateUserTodo(UserTodo userTodo)
        {
            if (userTodo is null)
                throw new ArgumentNullException(nameof(UserTodo));

            userTodoRepository.Update(userTodo);
        }
    }
}
