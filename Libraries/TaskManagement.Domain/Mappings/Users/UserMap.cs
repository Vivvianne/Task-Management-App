using TaskManagement.Domain.Models.Users;

namespace TaskManagement.Domain.Mappings.Users
{
    /// <summary>
    /// Represents a user map
    /// </summary>
    public class UserMap : TaskManagementEntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable(nameof(User));

            this.HasKey(user => user.Id);

            this.HasIndex(user => user.EntityGuid).IsUnique();
                
        }
    }
}
