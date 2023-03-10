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
    }
}
