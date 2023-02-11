using System;

namespace TaskManagement.Domain.Models.Core
{
    /// <summary>
    /// Represents a guided entity
    /// </summary>
    public interface IGuidedEntity
    {
        /// <summary>
        /// Gets or sets the entity guid
        /// </summary>
        Guid EntityGuid { get; set; }
    }
}
