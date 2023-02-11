using System;
using System.Collections.Generic;
using TaskManagement.Domain.Models.Core;

namespace TaskManagement.Domain.Models.Users
{
    /// <summary>
    /// Represents a user
    /// </summary>
    public class User : BaseEntity, IGuidedEntity
    {
        private ICollection<UserTodo> _usersTodos;

        public User() 
        {
            this.EntityGuid= Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the entity guid
        /// </summary>
        public Guid EntityGuid { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user todos
        /// </summary>
        public virtual ICollection<UserTodo> UserTodos
        {
            get { return _usersTodos ?? (_usersTodos = new List<UserTodo>()); }
            protected set { _usersTodos = value; }
        }
    }
}
