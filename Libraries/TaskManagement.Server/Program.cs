using System;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using TaskManagement.Domain.Services;
using Autofac;
using TaskManagement.Domain.Data.Infrastructure;
using TaskManagement.Domain.Services.Users;
using TaskManagement.Domain.Services.Todos;
using TaskManagement.Domain.Services.Options;
using TaskManagement.Domain.Data;
using Autofac.Core;
using TaskManagement.Domain.Models.Todos;
using System.Collections.Generic;
using TaskManagement.Domain;

namespace TaskManagement.Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder
                .Register<ITaskManagementDataProvider>(c => new TaskManagementDataProvider("Data Source=localhost;Initial Catalog=TaskManagement;Integrated Security=True"))
                .InstancePerLifetimeScope();

            containerBuilder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<UserTodoService>().As<IUserTodoService>();
            containerBuilder.RegisterType<TodoService>().As<ITodoService>();
            containerBuilder.RegisterType<TodoTimelineService>().As<ITodoTimelineService>();
            containerBuilder.RegisterType<OptionService>().As<IOptionService>();

            IContainer container = containerBuilder.Build();

            Todo newTodo = new Todo
            {
                Name = "Test",
            };

            ITodoService todoService = container.Resolve<ITodoService>();

            todoService.InsertTodo(newTodo);

            List<Todo> todos = todoService.GetAllTodos();

            foreach (Todo todo in todos)
            {
                Console.WriteLine(todo.Name);
            }

            //TcpChannel serverChannel = new TcpChannel(8085);
            //ChannelServices.RegisterChannel(serverChannel);
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof
            //               (RemoteAdd), "RemoteAdd", WellKnownObjectMode.Singleton);
            //Console.Write("Sever is  Ready........");
            Console.Read();
        }
    }
}
