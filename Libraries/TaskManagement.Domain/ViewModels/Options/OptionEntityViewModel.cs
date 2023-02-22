using System;

namespace TaskManagement.Domain.ViewModels.Options
{
    /// <summary>
    /// Represents an option view model
    /// </summary>
    [Serializable]
    public class OptionEntityViewModel
    {
        public OptionEntityViewModel() { }

        /// <summary>
        /// Gets or sets the label
        /// </summary>
        public string Label { get; set; }
    }
}
