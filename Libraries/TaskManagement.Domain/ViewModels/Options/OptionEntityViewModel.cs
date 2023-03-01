using System;
using TaskManagement.Domain.Models.Core;

namespace TaskManagement.Domain.ViewModels.Options
{
    /// <summary>
    /// Represents an option view model
    /// </summary>
    [Serializable]
    public class OptionEntityViewModel : IGuidedEntity
    {
        public OptionEntityViewModel() { }

        /// <summary>
        /// Gets or sets the label
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the entity guid
        /// </summary>
        public Guid EntityGuid { get; set; }

        /// <summary>
        /// Gets or sets the parent entity guid
        /// </summary>
        public Guid ParentEntityGuid { get; set; }
    }
}
