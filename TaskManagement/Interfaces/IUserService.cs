using TaskManagement.Models;

namespace TaskManagement.Interfaces
{
    public interface IUserService
    {
        Task<UserModel> RegisterUser(UserModel user);
        Task<UserModel> AuthenticateUser(string username, string password);
    }
}
