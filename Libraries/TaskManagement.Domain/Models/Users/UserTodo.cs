using System;
using TaskManagement.Domain.Models.Core;
using TaskManagement.Domain.Models.Todos;

namespace TaskManagement.Domain.Models.Users
{
    /// <summary>
    /// Represents a user to do
    /// </summary>
    public class UserTodo : BaseEntity, IGuidedEntity
    {
        public UserTodo() 
        {
            this.EntityGuid= Guid.NewGuid();
        }

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

        /// <summary>
        /// Gets or sets the entity guid
        /// </summary>
        public Guid EntityGuid { get; set; }
    }
}
