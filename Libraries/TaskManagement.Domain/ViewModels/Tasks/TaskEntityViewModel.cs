using System;
using TaskManagement.Domain.Models.Core;

namespace TaskManagement.Domain.ViewModels.Tasks
{
    /// <summary>
    /// Represents a task entity view model
    /// </summary>
    [Serializable]
    public class TaskEntityViewModel : IGuidedEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the user guid
        /// </summary>
        public Guid UserGuid { get; set; }

        /// <summary>
        /// Gets or sets the entity guid
        /// </summary>
        public Guid EntityGuid { get; set; }
    }
}
