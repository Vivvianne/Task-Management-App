using System;
using System.Collections.Generic;
using TaskManagement.Domain.Models.Core;
using TaskManagement.Domain.Models.Users;

namespace TaskManagement.Domain.Models.Todos
{
    /// <summary>
    /// Represents a to do
    /// </summary>
    public class Todo : BaseEntity, IGuidedEntity
    {
        private ICollection<UserTodo> _todoUsers;

        public Todo() 
        {
            this.EntityGuid= Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the entity guid
        /// </summary>
        public Guid EntityGuid { get; set; }

        /// <summary>
        /// Gets or sets a name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the parent identifier
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// Gets or sets the todo users
        /// </summary>
        public virtual ICollection<UserTodo> TodoUsers
        {
            get { return _todoUsers ?? (_todoUsers = new List<UserTodo>()); }
            protected set { _todoUsers = value; }
        }
    }
}
