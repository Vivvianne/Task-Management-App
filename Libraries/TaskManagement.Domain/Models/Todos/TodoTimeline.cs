using System;

namespace TaskManagement.Domain.Models.Todos
{
    /// <summary>
    /// Represents a todo timeline
    /// </summary>
    public class TodoTimeline : BaseEntity
    {
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a user todo entity guid
        /// </summary>
        public Guid UserTodoGuid { get; set; }
    }
}
