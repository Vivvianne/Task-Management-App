using System;
using TaskManagement.Domain.Data.Infrastructure;
using TaskManagement.Domain.Models.Todos;

namespace TaskManagement.Domain.Services.Todos
{
    /// <summary>
    /// Represents a todo timeline service
    /// </summary>
    public class TodoTimelineService : ITodoTimelineService
    {
        private readonly IRepository<TodoTimeline> todoTimelineRepository;

        public TodoTimelineService(IRepository<TodoTimeline> todoTimelineRepository)
        {
            this.todoTimelineRepository = todoTimelineRepository;
        }
        public void InsertTodoTimeline(TodoTimeline todoTimeline)
        {
            if (todoTimeline is null)
                throw new ArgumentNullException(nameof(TodoTimeline));

            todoTimelineRepository.Insert(todoTimeline);
        }

        public void UpdateTodoTimeline(TodoTimeline todoTimeline)
        {
            if (todoTimeline is null)
                throw new ArgumentNullException(nameof(TodoTimeline));

            todoTimelineRepository.Update(todoTimeline);
        }
    }
}
