using System.Collections.Generic;
using TaskManagement.Domain.Models.Todos;

namespace TaskManagement.Domain.Services.Todos
{
    /// <summary>
    /// Represents a todo timeline service
    /// </summary>
    public interface ITodoTimelineService
    {
        void InsertTodoTimeline(TodoTimeline todoTimeline);

        void UpdateTodoTimeline(TodoTimeline todoTimeline);
    }
}
