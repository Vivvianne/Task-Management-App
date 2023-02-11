using System.Data.Entity.ModelConfiguration;
using TaskManagement.Domain.Models.Todos;

namespace TaskManagement.Domain.Mappings.Todos
{
    /// <summary>
    /// Represents a todo mapping
    /// </summary>
    public class TodoMap : EntityTypeConfiguration<Todo>
    {
        public TodoMap()
        {
            this.ToTable(nameof(Todo));

            this.HasKey(todo => todo.Id);

            this.HasIndex(todo => todo.EntityGuid).IsUnique();
        }
    }
}
