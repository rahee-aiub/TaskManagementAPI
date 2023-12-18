using TaskManagement.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class UserService : IUserService
    {
        private readonly List<UserModel> _users = new List<UserModel>();
        private int _userIdCounter = 1;

        public async Task<UserModel> RegisterUser(UserModel user)
        {
            if (_users.Any(u => u.Username == user.Username))
            {
                // User with the same username already exists
                return null;
            }

            user.Id = _userIdCounter++;
            _users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<UserModel> AuthenticateUser(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return await Task.FromResult(user);
        }
    }
}
