using System.Data.Entity.ModelConfiguration;
using TaskManagement.Domain.Models.Todos;

namespace TaskManagement.Domain.Mappings.Todos
{
    /// <summary>
    /// Represents a todo timeline mapping 
    /// </summary>
    public class TodoTimelineMap : EntityTypeConfiguration<TodoTimeline>
    {
        public TodoTimelineMap()
        {
            this.HasKey(todoTimeline => todoTimeline.Id);

            this.HasIndex(todoTimeline => todoTimeline.UserTodoGuid);
        }
    }
}
