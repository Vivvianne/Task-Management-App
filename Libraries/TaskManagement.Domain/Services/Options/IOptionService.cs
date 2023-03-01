using System;
using System.Collections.Generic;
using TaskManagement.Domain.Models.Options;

namespace TaskManagement.Domain.Services.Options
{
    /// <summary>
    /// Represents an option service
    /// </summary>
    public interface IOptionService
    {
        /// <summary>
        /// Gets all options
        /// </summary>
        /// <returns>Options</returns>
        List<Option> GetOptions();

        /// <summary>
        /// Inserts an option
        /// </summary>
        void InsertOption(Option option);

        /// <summary>
        /// Update an option
        /// </summary>
        void UpdateOption(Option option);

        /// <summary>
        /// Get option by id
        /// </summary>
        /// <param name="id">Identity</param>
        /// <returns>Option</returns>
        Option GetOptionById(int id);

        /// <summary>
        /// Gets an option by entity guid
        /// </summary>
        /// <param name="entityGuid">Entity guid</param>
        /// <returns>Option</returns>
        Option GetOptionByEntityGuid(Guid entityGuid);
    }
}
