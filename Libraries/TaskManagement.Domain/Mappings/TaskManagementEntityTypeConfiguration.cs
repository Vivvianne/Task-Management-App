using System.Data.Entity.ModelConfiguration;

namespace TaskManagement.Domain.Mappings
{
    /// <summary>
    /// Represents a task management entity type configuration
    /// </summary>
    public class TaskManagementEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : class
    {
        protected TaskManagementEntityTypeConfiguration() { }


    }
}
