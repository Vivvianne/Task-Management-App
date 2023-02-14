using System.Data.Entity.ModelConfiguration;
using TaskManagement.Domain.Models.Users;

namespace TaskManagement.Domain.Mappings.Users
{
    /// <summary>
    /// Represents a user todo mapping
    /// </summary>
    public class UserTodoMap : EntityTypeConfiguration<UserTodo>
    {
        public UserTodoMap()
        {
            this.ToTable(nameof(UserTodo));

            this.HasKey(userTodo => new { userTodo.UserId, userTodo.TodoId });

            this.HasIndex(userTodo => userTodo.EntityGuid).IsUnique();

            this.Ignore(userTodo => userTodo.Id);

            this.HasRequired(userTodo => userTodo.User)
                .WithMany()
                .HasForeignKey(userTodo => userTodo.UserId);

            this.HasRequired(userTodo => userTodo.Todo)
                .WithMany()
                .HasForeignKey(userTodo => userTodo.TodoId);
        }
    }
}
