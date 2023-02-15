using TaskManagement.Domain.Models.Users;

namespace TaskManagement.Domain.Services.Users
{
    /// <summary>
    /// Represents a user todo service
    /// </summary>
    public interface IUserTodoService
    {
        /// <summary>
        /// Inserts a user todo
        /// </summary>
        /// <param name="userTodo">User todo</param>
        void InsertUserTodo(UserTodo userTodo);

        /// <summary>
        /// Updates a user todo
        /// </summary>
        /// <param name="userTodo">user todo</param>
        void UpdateUserTodo(UserTodo userTodo);
    }
}
