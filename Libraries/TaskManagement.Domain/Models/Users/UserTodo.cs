using TaskManagement.Domain.Models.Todos;

namespace TaskManagement.Domain.Models.Users
{
    /// <summary>
    /// Represents a user to do
    /// </summary>
    public class UserTodo : BaseEntity
    {
        /// <summary>
        /// Gets or sets the user identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the to do identifier
        /// </summary>
        public int TodoId { get; set; }

        /// <summary>
        /// Gets or sets the user
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets the todo
        /// </summary>
        public Todo Todo { get; set; }
    }
}
