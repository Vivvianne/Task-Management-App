using System.Data.Entity.Infrastructure;

namespace TaskManagement.Domain.Data
{
    public class TaskManagementDataProviderFactory : IDbContextFactory<TaskManagementDataProvider>
    {
        public TaskManagementDataProvider Create()
        {
            return new TaskManagementDataProvider("Data Source=localhost;Initial Catalog=TaskManagement;Integrated Security=True");
        }
    }
}
