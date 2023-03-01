using System;
using TaskManagement.Domain.Models.Core;

namespace TaskManagement.Domain.ViewModels.Users
{
    /// <summary>
    /// Represents a user entity view model
    /// </summary>
    [Serializable]
    public class UserEntityViewModel : IGuidedEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the entity guid
        /// </summary>
        public Guid EntityGuid { get; set; }
    }
}
