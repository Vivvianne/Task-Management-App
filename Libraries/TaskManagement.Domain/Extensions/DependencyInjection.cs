using Autofac;
using AutoMapper;
using System;
using System.Linq;
using System.Reflection;
using TaskManagement.Domain.Data.Infrastructure;
using TaskManagement.Domain.Data;
using TaskManagement.Domain.Services.Options;
using TaskManagement.Domain.Services.Todos;
using TaskManagement.Domain.Services.Users;
using System.Data.Entity.Migrations;
using TaskManagement.Domain.Migrations;
using System.Data.Entity.Infrastructure;

namespace TaskManagement.Domain.Extensions
{
    /// <summary>
    /// Represents dependency registration
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Builds application dependencies
        /// </summary>
        public static IContainer BuildDependencyContainer()
        {

            ContainerBuilder containerBuilder = BuildDependencies();

            return containerBuilder.Build();
        }

        public static ContainerBuilder BuildDependencies()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder
                .Register<ITaskManagementDataProvider>(c => new TaskManagementDataProvider("Data Source=localhost;Initial Catalog=TaskManagement;Integrated Security=True"))
                .InstancePerLifetimeScope();

            var configuration = new Configuration();
            var migrator = new DbMigrator(configuration);
            migrator.Update();

            containerBuilder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<UserTodoService>().As<IUserTodoService>();
            containerBuilder.RegisterType<TodoService>().As<ITodoService>();
            containerBuilder.RegisterType<TodoTimelineService>().As<ITodoTimelineService>();
            containerBuilder.RegisterType<OptionService>().As<IOptionService>();

            containerBuilder.RegisterAutoMapper();

            return containerBuilder;
        }

        /// <summary>
        /// Registers automapper
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterAutoMapper(this ContainerBuilder builder)
        {
            var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            var assembliesTypes = assemblyNames
                .Where(a => a.Name.Equals("TaskManagement.Domain", StringComparison.OrdinalIgnoreCase))
                .SelectMany(an => Assembly.Load(an).GetTypes())
                .Where(p => typeof(Profile).IsAssignableFrom(p) && p.IsPublic && !p.IsAbstract)
                .Distinct();

            var autoMapperProfiles = assembliesTypes
                .Select(p => (Profile)Activator.CreateInstance(p)).ToList();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                foreach (var profile in autoMapperProfiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
