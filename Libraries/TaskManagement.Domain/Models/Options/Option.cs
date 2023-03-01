using System;
using TaskManagement.Domain.Models.Core;

namespace TaskManagement.Domain.Models.Options
{
    /// <summary>
    /// Represents an option
    /// </summary>
    [Serializable]
    public class Option : BaseEntity, IGuidedEntity
    {
        public Option() 
        {
            this.EntityGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the entity guid
        /// </summary>
        public Guid EntityGuid { get; set; }

        /// <summary>
        /// Gets or sets the label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the parent option id
        /// </summary>
        public int ParentOptionId { get; set; } 
    }
}
