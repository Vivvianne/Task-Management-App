using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Domain.Data.Infrastructure;
using TaskManagement.Domain.Models.Options;

namespace TaskManagement.Domain.Services.Options
{
    /// <summary>
    /// Represents an option service
    /// </summary>
    public class OptionService : IOptionService
    {
        private readonly IRepository<Option> optionRepository;

        public OptionService(IRepository<Option> optionRepository)
        {
            this.optionRepository = optionRepository;
        }

        /// <summary>
        /// Gets an option by identifier
        /// </summary>
        /// <param name="id">idnetifier</param>
        /// <returns>Option</returns>
        public Option GetOptionById(int id)
        {
            return optionRepository.GetById(id);
        }

        /// <summary>
        /// Gets all options
        /// </summary>
        /// <returns></returns>
        public List<Option> GetOptions()
        {
            return optionRepository.Table.ToList();
        }

        public void InsertOption(Option option)
        {
            if (option is null)
                throw new ArgumentNullException(nameof(Option));

            optionRepository.Insert(option);
        }

        /// <summary>
        /// Update option
        /// </summary>
        /// <param name="option">Option</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void UpdateOption(Option option)
        {
            if (option is null)
                throw new ArgumentNullException(nameof(Option));

            optionRepository.Update(option);
        }
    }
}
