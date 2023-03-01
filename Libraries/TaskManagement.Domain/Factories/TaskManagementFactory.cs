using Autofac;
using AutoMapper;
using System;
using System.Collections.Generic;
using TaskManagement.Domain.Models.Options;
using TaskManagement.Domain.Services.Options;
using TaskManagement.Domain.ViewModels.Options;
using TaskManagement.Domain.Extensions;
using Autofac.Core;
using TaskManagement.Domain.ViewModels.Users;
using TaskManagement.Domain.Services.Users;
using TaskManagement.Domain.Models.Users;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using TaskManagement.Domain.ViewModels.Tasks;
using TaskManagement.Domain.Services.Todos;
using TaskManagement.Domain.Models.Todos;

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
                IOptionService optionService = scope.Resolve<IOptionService>();

                Option newOption = new Option
                {
                    Label = optionViewModel.Label,
                    ParentOptionId = optionViewModel.ParentEntityGuid == Guid.Empty ? 0 : (optionService.GetOptionByEntityGuid(optionViewModel.ParentEntityGuid)).Id
                };

                optionService.InsertOption(newOption);

                List<Option> options = optionService.GetOptions();

                foreach (var option in options)
                {
                    optionEntityViewModels.Add(new OptionEntityViewModel
                    {
                        Label = option.Label,
                        EntityGuid = option.EntityGuid
                    });
                }
                return optionEntityViewModels;
            }
        }

        public List<OptionEntityViewModel> ListOptions()
        {
            List<OptionEntityViewModel> optionEntityViewModels = new List<OptionEntityViewModel>();

            using (var scope = this.container.BeginLifetimeScope()) 
            {
                IOptionService optionService = scope.Resolve<IOptionService>();

                List<Option> options = optionService.GetOptions();

                foreach (var option in options)
                {
                    optionEntityViewModels.Add(new OptionEntityViewModel
                    {
                        Label = option.Label,
                        EntityGuid = option.EntityGuid
                    });
                }
                return optionEntityViewModels;
            }
        }

        public List<UserEntityViewModel> AddUser(UserEntityViewModel userEntityViewModel)
        {
            List<UserEntityViewModel> userEntityViewModels = new List<UserEntityViewModel>();

            using (var scope = this.container.BeginLifetimeScope())
            {
                IUserService userService = scope.Resolve<IUserService>();

                User newUser = new User
                {
                    Name = userEntityViewModel.Name
                };

                userService.InsertUser(newUser);

                List<User> users = userService.GetUsers();

                foreach (var user in users)
                {
                    userEntityViewModels.Add(new UserEntityViewModel
                    {
                        Name = user.Name
                    });
                }
                return userEntityViewModels;
            }

        }

        public List<UserEntityViewModel> GetUsers()
        {
            List<UserEntityViewModel> userEntityViewModels = new List<UserEntityViewModel>();

            using (var scope = this.container.BeginLifetimeScope())
            {
                IUserService userService = scope.Resolve<IUserService>();

                List<User> users = userService.GetUsers();

                foreach (var user in users)
                {
                    userEntityViewModels.Add(new UserEntityViewModel
                    {
                        Name = user.Name,
                        EntityGuid = user.EntityGuid
                    });
                }
                return userEntityViewModels;
            }
        }

        public List<TaskEntityViewModel> AddTask(TaskEntityViewModel taskEntityViewModel)
        {
            List<TaskEntityViewModel> taskEntityViewModels = new List<TaskEntityViewModel>();

            using (var scope = this.container.BeginLifetimeScope())
            {
                IUserService userService = scope.Resolve<IUserService>();
                ITodoService todoService = scope.Resolve<ITodoService>();
                IUserTodoService userTodoService = scope.Resolve<IUserTodoService>();

                User assignedUser = userService.GetUsersByEntityGuid(taskEntityViewModel.UserGuid);

                Todo newTodo = new Todo
                {
                    Name = taskEntityViewModel.Name,
                };

                todoService.InsertTodo(newTodo);

                userTodoService.InsertUserTodo(new UserTodo
                {
                    Todo = newTodo,
                    User = assignedUser
                });

                List<Todo> todos = todoService.GetTodos();

                foreach (var todo in todos)
                {
                    taskEntityViewModels.Add(new TaskEntityViewModel
                    {
                        Name = todo.Name,
                        EntityGuid = todo.EntityGuid
                    });
                }

                return taskEntityViewModels;
            }
        }

        #endregion
    }
}
