using System.Data.Entity;
using System.Threading.Tasks;
using TaskManagement.Domain.Models;

namespace TaskManagement.Domain.Data
{
    /// <summary>
    /// Represents the DB context
    /// </summary>
    public interface ITaskManagementDataProvider
    {
        /// <summary>
        /// Creates a DbSet that can be used to query ad save instances of entity
        /// </summary>
        /// <typeparam name="TEntity">Entity Type</typeparam>
        /// <returns>A set for the given type</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        /// <summary>
        /// Saves all changes made in this context to the database
        /// </summary>
        /// <returns>The number of state entries writteb to the datatbase</returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Saves all changes made in this context to the database
        /// </summary>
        /// <returns>The number of state entries writteb to the datatbase</returns>
        int SaveChanges();
    }
}
