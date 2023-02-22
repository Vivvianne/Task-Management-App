using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using TaskManagement.Domain.Models.Options;
using TaskManagement.Domain.Services.Options;
using TaskManagement.Domain.ViewModels.Options;
using TaskManagement.Domain.Extensions;
using Autofac.Core;

namespace TaskManagement.Domain.Factories
{
    /// <summary>
    /// Represents a task management factory
    /// </summary>
    public class TaskManagementFactory : MarshalByRefObject
    {
        #region Fields

        private readonly IMapper mapper;
        private readonly IOptionService optionService;
        private IContainer container;

        #endregion

        #region Ctor

        public TaskManagementFactory() 
        {
            this.container = DependencyInjection.BuildDependencyContainer();
        }

        public TaskManagementFactory(IMapper mapper,
            IOptionService optionService)
        {
            this.mapper = mapper;
            this.optionService = optionService;
        }

        #endregion

        #region Methods

        public List<OptionEntityViewModel> AddOption(OptionEntityViewModel optionViewModel) 
        {
            if (optionViewModel == null)
                throw new ArgumentNullException(nameof(optionViewModel));

            List<OptionEntityViewModel> optionEntityViewModels = new List<OptionEntityViewModel>();

            using (var scope = this.container.BeginLifetimeScope())
            {
                IMapper mapper = scope.Resolve<IMapper>();
                IOptionService optionService = scope.Resolve<IOptionService>();

                Option newOption = new Option
                {
                    Label = optionViewModel.Label
                };

                optionService.InsertOption(newOption);

                List<Option> options = optionService.GetOptions();

                foreach (var option in options) 
                {
                    optionEntityViewModels.Add(new OptionEntityViewModel
                    {
                        Label = optionViewModel.Label,
                    });
                }
                return optionEntityViewModels;
            }
        }

        #endregion
    }
}
