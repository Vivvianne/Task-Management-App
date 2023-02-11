using System;

namespace TaskManagement.Domain.Models
{
    /// <summary>
    /// Represents a base entity
    /// </summary>
    public class BaseEntity
    {
        public BaseEntity() 
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = DateTime.UtcNow;
        }

        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the date created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Gets or sets the date updated
        /// </summary>
        public DateTime DateUpdated { get; set; }
    }
}
