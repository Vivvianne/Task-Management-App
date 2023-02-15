using TaskManagement.Domain.Models.Users;

namespace TaskManagement.Domain.Services.Users
{
    /// <summary>
    /// Represents a user service
    /// </summary>
    public interface IUserService
    {
        void InsertUser(User user);

        void UpdateUser(User user);

    }
}
