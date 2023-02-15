using TaskManagement.Domain.Models.Todos;

namespace TaskManagement.Domain.Mappings.Todos
{
    /// <summary>
    /// Represents a todo timeline mapping 
    /// </summary>
    public class TodoTimelineMap : TaskManagementEntityTypeConfiguration<TodoTimeline>
    {
        public TodoTimelineMap()
        {
            this.ToTable(nameof(TodoTimeline));

            this.HasKey(todoTimeline => todoTimeline.Id);

            this.HasIndex(todoTimeline => todoTimeline.UserTodoGuid);
        }
    }
}
